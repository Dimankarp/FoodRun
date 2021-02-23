﻿using System;
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

        private static Map MapFiller(int type = 1)
        {
            Map map = new Map();
            switch (type)
            {
                case 1://Map #1
                    map.OrigMapArray = new char[10][]
                    {
                   new char[]{'#', '#','#','#','#','#','#','#','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','#','#','#','#','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '*','*','*','*','*','*','*','#'},
                   new char[]{'#', '#','#','#','#','#','#','#','#'}
                    };
                    map.Height = 10;
                    map.Width = map.OrigMapArray[0].Length;
                    map.CurrMapArray = new char[10][];
                    for (int i = 0; i < map.Height; i++)
                    {
                        map.CurrMapArray[i] = new char[10];
                    }
                    break;

                case 2: //Map #2
                    break;

                case 3://Map #3
                    break;



            }

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
