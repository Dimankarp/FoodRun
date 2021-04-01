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
        public Multiplayer.MultiplayerGame.GameInfo GameInfo;

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
            GameInfo = ReceiveGameInfo(ClientSocket, false) as Multiplayer.MultiplayerGame.GameInfo;
            while (true)
            {
                GameInfo = ReceiveGameInfo(ClientSocket) as Multiplayer.MultiplayerGame.GameInfo;

                ClientPlayer.MovementAsync(GameInfo.Map);
                SendPlayerPos(ClientSocket);

                Interface.MultiplayerMapDraw(GameInfo.Map, GameInfo.Players, GameInfo.Food);
                Interface.MultiplayerShowPoints(GameInfo.Map, GameInfo.Players);

            }
        }

        private void SendPlayerPos(Socket ClientSocket)
        {
            Message message = new Message();

            message.PacketWrapper(Foo.Serialize(ClientPlayer).Data);

            ClientSocket.Send(message.Data);
        }

        private object ReceiveGameInfo(Socket Client, bool ReceiveTimeOut = true)
        {
            Message message = new Message();
            if(ReceiveTimeOut) Client.ReceiveTimeout = 100;
            try
            {
                byte[] dataLength = new byte[4];
                Client.Receive(dataLength);
                int Length = BitConverter.ToInt32(dataLength, 0);

                message.Data = new byte[Length];
                Client.Receive(message.Data);
                return Foo.Deserialize(message);
            }
            catch
            {
                return GameInfo;
            }

        }
    }
}

