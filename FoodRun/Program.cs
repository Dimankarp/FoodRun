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
                case 1://Map #1 - The Original one
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
                    break;
            }
            map.Height = map.OrigMapArray.Length;
            map.Width = map.OrigMapArray[0].Length;
            map.CurrMapArray = map.OrigMapArray.Select(a => (char[])a.Clone()).ToArray();
            return map; 
        }

        static void Main(string[] args)
        {    
            Map map = MapFiller();
            Player player = new Player();
            Game NewGame = new Game(map, player);
            NewGame.Start();
        }

    }
}
