﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace FoodRunners
{
    class Server
    {
        public int Port { get; set; }
        public string HostIP { get; set; }
        public bool Working = false;
        public Multiplayer.MultiplayerGame Game;
        public Player HostPlayer;
        public Dictionary<Socket, Player> ConnectedPlayers = new Dictionary<Socket, Player>();//Not including the host!

        public Server(string ipAdress, int port)
        {
            HostIP = ipAdress;
            Port = port;
        }

        public void Start(int NumOfPlayers, Program.Map Map)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(HostIP), Port);
            Socket ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ListenSocket.Bind(ipPoint);
            ListenSocket.Listen(NumOfPlayers-1);//Here should be the number of Players-1
            while (ConnectedPlayers.Count < NumOfPlayers-1)
            {
                Socket newPlayer = ListenSocket.Accept();
                ConnectedPlayers.Add(newPlayer, ReceiveData(newPlayer) as Player);
            }
            PlayerInitializing();

            List<Player> Players = ConnectedPlayers.Values.ToList();
            Players.Add(HostPlayer);

            Game = new Multiplayer.MultiplayerGame();
            Game.Map = Map;
            Game.Players = Players;

            Game.StartAsync();
            while (Game.State == false) { }
            while (true)
            {
                SendGameInfo();
                HostPlayer.MovementAsync(Map);//Host player movement
                for (int i = 0; i < ConnectedPlayers.Count; i++)
                {
                    PlayerMovement(ConnectedPlayers.Keys.ToArray()[i]);
                }
                Players = ConnectedPlayers.Values.ToList();
                Players.Add(HostPlayer);
                Game.Players = Players;

            }
        }

        private void PlayerInitializing()
        {
            HostPlayer = new Player() { Character = '0' };
            for (int i = 0; i < ConnectedPlayers.Count; i++)
            {
                ConnectedPlayers.Values.ToList()[i].Character = (char)(i + 1);

                Message message = new Message();
                message.PacketWrapper(Foo.Serialize(ConnectedPlayers.Values.ToList()[i]).Data);
                ConnectedPlayers.Keys.ToList()[i].Send(message.Data);
            }
        }

        private async void PlayerMovementAsync(Socket PlayerSocket)
        {
            await Task.Run(() => PlayerMovement(PlayerSocket));
        }

        private void PlayerMovement(Socket PlayerSocket)
        {
            ConnectedPlayers[PlayerSocket] = ReceiveData(PlayerSocket) as Player;
        }

        private object ReceiveData(Socket ReceivingSocket)
        {
            Message message = new Message();
            ReceivingSocket.ReceiveTimeout = 100;
            try
            {
                byte[] dataLength = new byte[4];
                ReceivingSocket.Receive(dataLength);
                int Length = BitConverter.ToInt32(dataLength, 0);

                message.Data = new byte[Length];
                ReceivingSocket.Receive(message.Data);

                return Foo.Deserialize(message);
            }
            catch
            {
                return ConnectedPlayers[ReceivingSocket];
            }
        }

        private void SendGameInfo()
        {
            Message message = new Message();
            Multiplayer.MultiplayerGame.GameInfo Info = Game.GetGameInfo();

            message.PacketWrapper(Foo.Serialize(Info).Data);

            for (int i = 0; i < ConnectedPlayers.Count; i++)
            {
                ConnectedPlayers.Keys.ToArray()[i].Send(message.Data);
            }
        }




    }
}
