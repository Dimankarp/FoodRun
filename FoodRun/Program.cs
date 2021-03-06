using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Program
    {
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

            }
            map.Number = type;
            map.Height = map.OrigMapArray.Length;
            map.Width = map.OrigMapArray[0].Length;
            map.CurrMapArray = map.OrigMapArray.Select(a => (char[])a.Clone()).ToArray();
            return map;
        }

        static void Main(string[] args)
        {
            Interface Interf = new Interface();
            string[] Answers = { "Single-Player", "Multiplayer(WIP)", "Exit" };
            string Question = "Main Menu";
            switch (Interf.AnswerInterface(Question, Answers))
            {
                case 0:
                    SinglePlayerMode();
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }

        }

        private static void SinglePlayerMode()
        {
            Interface Interf = new Interface();
            Map map = MapFiller();
            Player player = new Player();
            string[] Settings = { "Start", "Change Map", "Change AI's Difficulty" };
            string Question;
            int CursorPos = 0;
            while (true)
            {
                Question = "Current map is:" + map.Name;
                switch (Interf.AnswerInterface(Question, Settings, CursorPos))
                {
                    case 0:
                        Game NewGame = new Game(map, player);
                        NewGame.Start();
                        break;
                    case 1:
                        CursorPos = 1;
                        if (map.Number == 5) map = MapFiller(1); //Yes, you have to manually change number of maps, when ones are added...Sorry, I guess...
                        else map = MapFiller(map.Number + 1);
                        break;
                    case 2:
                        break;

                }
            }
        }

        private static void MultiplayerMode()
        {

        }
    }


}

