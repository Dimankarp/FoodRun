using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace FoodRunners
{
    class Client
    {
        public int serverPort { get; set; }
        public string serverIP { get; set; }
        public bool Connected = false;
        public Player ClientPlayer;

        public Client(string ipAdress, int port)
        {
            serverIP = ipAdress;
            serverPort = port;
        }


        public void Connect()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

            Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            ClientPlayer = new Player();

            ClientSocket.Connect(ipPoint);
            SendPlayerPos(ClientSocket);
            while (true)
            {
                Multiplayer.MultiplayerGame.GameInfo Game = ReceiveGameInfo(ClientSocket) as Multiplayer.MultiplayerGame.GameInfo;
                Game.Players[0] = ClientPlayer;
                ClientPlayer.MovementAsync(Game.Map);
                SendPlayerPosAsync(ClientSocket);
                // ArraySegment<byte> seg = new ArraySegment<byte>((Foo.Serialize(ClientPlayer).Data),0,299);
                //  ClientSocket.SendAsync(seg,SocketFlags.None);
                Interface.MultiplayerMapDraw(Game.Map, Game.Players, Game.Food);
                Interface.MultiplayerShowPoints(Game.Map, Game.Players);

            }
        }

       async private void SendPlayerPosAsync(Socket ClientSocket)
        {
            await Task.Run(() => SendPlayerPos(ClientSocket));
        }

        private void SendPlayerPos(Socket ClientSocket)
        {
            Message message = new Message();

            byte[] playerInfo = Foo.Serialize(ClientPlayer).Data;
            byte[] packetSize = BitConverter.GetBytes(playerInfo.Length);
            message.Data = new byte[playerInfo.Length + packetSize.Length];
            packetSize.CopyTo(message.Data, 0);
            playerInfo.CopyTo(message.Data, packetSize.Length);

            ClientSocket.Send(message.Data);
        }

        private object ReceiveGameInfo(Socket Client)
        {
            Message message = new Message();

            byte[] dataLength = new byte[4];
            Client.Receive(dataLength);
            int Length = BitConverter.ToInt32(dataLength, 0);

            message.Data = new byte[Length];
            Client.Receive(message.Data);
            return Foo.Deserialize(message);

        }
    }
}

