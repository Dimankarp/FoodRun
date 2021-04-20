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

            Server.LobbyInfo LobbyInfo = ReceiveGameInfo(ClientSocket, false) as Server.LobbyInfo; //Creating Lobby

            string[] NullArray = new string[0];
            string Title = $"Waiting for Players to connect - {LobbyInfo.NumberOfPlayers - 1 - LobbyInfo.ConnectedPlayers.Count}";
            Interface.AnswerInterface(Title, NullArray);//Lobby Initialization
            Console.CursorTop += 2;
            int OrigTop = Console.CursorTop;
            for(int i = 0; i < LobbyInfo.ConnectedPlayers.Count; i++)
            {
                Console.SetCursorPosition(6, OrigTop + 2 * i);
                Console.Write("\x4 {0} - is connected.", LobbyInfo.ConnectedPlayers[i].Character);
            }

            int NumOfPlayersToConnect = LobbyInfo.NumberOfPlayers - 1 - LobbyInfo.ConnectedPlayers.Count;
            for(int i = 0; i < NumOfPlayersToConnect; i++)
            {
                LobbyInfo = ReceiveGameInfo(ClientSocket, false) as Server.LobbyInfo;
                Title = $"Waiting for Players to connect - {NumOfPlayersToConnect - i}";
                Interface.AnswerInterfaceTitleChange(Title);
                Console.SetCursorPosition(6, OrigTop + 2 * LobbyInfo.ConnectedPlayers.Count - 1);
                Console.Write("\x4 {0} - is connected.", LobbyInfo.ConnectedPlayers.Last().Character);
            }
            Console.Clear();//End of Lobby stage

            ClientPlayer = ReceiveGameInfo(ClientSocket, false) as Player;//Player registration

            GameInfo = ReceiveGameInfo(ClientSocket, false) as Multiplayer.MultiplayerGame.GameInfo;//Game registration
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
            if (ReceiveTimeOut) Client.ReceiveTimeout = 100;
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

