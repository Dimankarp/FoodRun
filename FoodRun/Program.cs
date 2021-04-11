using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Program
    {
        [Serializable]
        public struct Map
        {
            public string Name;
            public int Number;
            public int Height;
            public int Width;
            public char[][] CurrMapArray;
            public char[][] OrigMapArray;

        }

        private static Map MapFiller(int type = 1) //A Map Chooser!
        {
            Map map = new Map();
            switch (type)
            {
                case 1://Map #1 - The Rectangle of Boringness
                    map.OrigMapArray = new char[15][]
                    {
                   new char[]{'#', '#','#','#','#','#','#','#','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','#','#','*','#','#','*','#'},
                   new char[]{'#', '*','#','#','*','#','#','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','#','#','*','#','#','*','#'},
                   new char[]{'#', '*','#','#','*','#','#','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '#','#','#','#','#','#','#','#'},
                    };
                    map.Name = "The Rectangle of Boringness";
                    break;

                case 2: //Map #2 - The Circle(Sort of...)
                    map.OrigMapArray = new char[15][]
                    {
                   new char[]{' ',' ',' ','#','#','#',' ',' ',' '},
                   new char[]{' ',' ','#','*','*','*','#',' ',' '},
                   new char[]{' ','#','*','*','*','*','*','#',' '},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','#'},
                   new char[]{' ','#','*','*','*','*','*','#',' '},
                   new char[]{' ',' ','#','*','*','*','#',' ',' '},
                   new char[]{' ',' ',' ','#','#','#',' ',' ',' '},
                    };
                    map.Name = "The Circle of Fun";
                    break;

                case 3://Map #3 -  The Sand Clocks...Of Death!
                    map.OrigMapArray = new char[15][]
                    {
                   new char[]{' ', '#','#','#','#','#','#','#',' '},
                   new char[]{' ', '#','*','*','*','*','*','#',' '},
                   new char[]{' ', '#','*','*','*','*','*','#',' '},
                   new char[]{' ', '#','*','*','*','*','*','#',' '},
                   new char[]{' ', ' ','#','*','*','*','#',' ',' '},
                   new char[]{' ', ' ','#','*','*','*','#',' ',' '},
                   new char[]{' ', ' ',' ','#','*','#',' ',' ',' '},
                   new char[]{' ', ' ',' ','#','*','#',' ',' ',' '},//The middle
                   new char[]{' ', ' ',' ','#','*','#',' ',' ',' '},
                   new char[]{' ', ' ','#','*','*','*','#',' ',' '},
                   new char[]{' ', ' ','#','*','*','*','#',' ',' '},
                   new char[]{' ', '#','*','*','*','*','*','#',' '},
                   new char[]{' ', '#','*','*','*','*','*','#',' '},
                   new char[]{' ', '#','*','*','*','*','*','#',' '},
                   new char[]{' ', '#','#','#','#','#','#','#',' '},
                    };
                    map.Name = "The Sand Clocks...Of Death";
                    break;

                case 4://Map #4 - The Labyrinth of Illegible symbols
                    map.OrigMapArray = new char[15][]
                    {
                   new char[]{'#', '#','#','#','#','#','#','#','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','#','#','#','#','*','#','#'},
                   new char[]{'#', '*','*','*','#','*','*','*','#'},
                   new char[]{'#', '#','#','*','#','*','#','*','#'},
                   new char[]{'#', '*','#','*','#','*','#','*','#'},
                   new char[]{'#', '*','#','*','#','*','#','*','#'},
                   new char[]{'#', '*','*','*','*','*','#','*','#'},
                   new char[]{'#', '*','#','#','#','#','#','*','#'},
                   new char[]{'#', '*','*','*','*','*','#','*','#'},
                   new char[]{'#', '#','#','#','#','*','#','#','#'},
                   new char[]{'#', '*','*','*','*','*','#','*','#'},
                   new char[]{'#', '*','#','#','#','#','#','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '#','#','#','#','#','#','#','#'},
                    };
                    map.Name = "The Labyrinth of Blurry Walls";
                    break;

                case 5://Map #5 - The Box of Boxes
                    map.OrigMapArray = new char[15][]
                    {
                   new char[]{'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','#','#','#','#','#','*','#','#','#','#','#','*','#'},
                   new char[]{'#','*','#','*','*','*','*','*','*','*','*','*','#','*','#'},
                   new char[]{'#','*','#','*','#','#','#','*','#','#','#','*','#','*','#'},
                   new char[]{'#','*','#','*','#','*','*','*','*','*','#','*','#','*','#'},
                   new char[]{'#','*','#','*','#','*','#','*','#','*','#','*','#','*','#'},
                   new char[]{'#','*','*','*','*','*','*','#','*','*','*','*','*','*','#'},
                   new char[]{'#','*','#','*','#','*','#','*','#','*','#','*','#','*','#'},
                   new char[]{'#','*','#','*','#','*','*','*','*','*','#','*','#','*','#'},
                   new char[]{'#','*','#','*','#','#','#','*','#','#','#','*','#','*','#'},
                   new char[]{'#','*','#','*','*','*','*','*','*','*','*','*','#','*','#'},
                   new char[]{'#','*','#','#','#','#','#','*','#','#','#','#','#','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                    };
                    map.Name = "The Box of Boxes";
                    break;

                case 6://Map #6 - The Field of Rye
                    map.OrigMapArray = new char[15][]
                    {
                   new char[]{'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},         
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},            
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','*','*','*','*','*','*','*','*','*','*','*','*','*','#'},
                   new char[]{'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                    };
                    map.Name = "The Field of Rye";
                    break;

            }
            map.Number = type;
            map.Height = map.OrigMapArray.Length;
            map.Width = map.OrigMapArray[0].Length;
            map.CurrMapArray = map.OrigMapArray.Select(a => (char[])a.Clone()).ToArray();
            return map;
        }

        static void Main(string[] args)
        {

            string[] Answers = { "Single-Player", "Multiplayer", "Exit" };
            string Question = "Main Menu";
            switch (Interface.AnswerInterface(Question, Answers))
            {
                case 0:
                    SinglePlayerMode();
                    break;
                case 1:
                    MultiplayerMode();
                    break;
                case 2:
                    break;
            }

        }

        private static void SinglePlayerMode()
        {
            Map map = MapFiller();
            Player player = new Player();
            string[] Settings = { "Start", "Change Map", "Change AI's Difficulty" };
            string Question;
            int CursorPos = 0;
            int AIDifficulty = 3;
            while (true)
            {
                Question = $"Current map is:{map.Name}";
                switch (AIDifficulty)
                {
                    case 1:
                        Question += "||AI Difficulty - Hard";
                        break;
                    case 2:
                        Question += "||AI Difficulty - Medium";
                        break;
                    case 3:
                        Question += "||AI Difficulty - Easy";
                        break;

                }


                switch (Interface.AnswerInterface(Question, Settings, CursorPos))
                {
                    case 0:
                        Game NewGame = new Game(map, player);
                        NewGame.Start(AIDifficulty);
                        break;
                    case 1:
                        CursorPos = 1;
                        if (map.Number == 6) map = MapFiller(1); //Yes, you have to manually change number of maps, when ones are added...Sorry, I guess...
                        else map = MapFiller(map.Number + 1);
                        break;
                    case 2:
                        CursorPos = 2;
                        if (AIDifficulty == 1) AIDifficulty = 3;
                        else AIDifficulty--;
                        break;

                }
            }
        }

        private static void MultiplayerMode()
        {
            string[] Settings = { "Host Game", "Connect to a Hosted Game(Enter IP and Port)", "Connect to a Locally Hosted Game" };
            string Question = "Multyplayer Main Menu";
            int CursorPos = 0;
            while (true)
            {
                switch (Interface.AnswerInterface(Question, Settings, CursorPos))
                {
                    case 0:
                        HostGame();
                        break;
                    case 1:
                        CursorPos = 1;
                        string[] NetworkData;
                        if (!Interface.GetIPAndPort(Settings, 1, out NetworkData)) break;
                        ConnectToGame(NetworkData[0], int.Parse(NetworkData[1]));
                        break;
                    case 2:
                        ConnectToGame();
                        break;

                }
            }
        }
        private static void HostGame()
        {
            Map map = MapFiller();
            string[] Settings = { "Host", "Host Locally(Adress - 127.0.0.1:8005)","Change Map", "Change the Number of Players" };
            string Question;
            int CursorPos = 0;
            int NumOfPlayers = 2;
            while (true)
            {
                Question = $"Current map is:{map.Name}||Number of Players:{NumOfPlayers}";
                switch (Interface.AnswerInterface(Question, Settings, CursorPos))
                {
                    case 0:
                        string[] NetworkData;
                        if (!Interface.GetIPAndPort(Settings, 0, out NetworkData)) break;
                        Server server = new Server(NetworkData[0], int.Parse(NetworkData[1]));
                        Console.Clear();
                        server.Start(NumOfPlayers, map);
                        break;
                    case 1:
                        Server LocalServer = new Server("127.0.0.1", 8005);
                        Console.Clear();
                        LocalServer.Start(NumOfPlayers, map);
                        break;

                    case 2:
                        CursorPos = 2;
                        if (map.Number == 6) map = MapFiller(1); //Yes, you have to manually change number of maps, when ones are added...Sorry, I guess...
                        else map = MapFiller(map.Number + 1);
                        break;
                    case 3:
                        CursorPos = 3;
                        if (NumOfPlayers == 5) NumOfPlayers = 2;
                        else NumOfPlayers++;
                        break;

                }

            }
        }

        private static void ConnectToGame(string IP = "127.0.0.1", int Port = 8005)
        {
            Client client = new Client("127.0.0.1", 8005);
            Console.Clear();
            client.Connect();
        }
    }
}

