﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Interface
    {
        public Player currPlayer;
        public List<Player> Players = new List<Player>();
        public Program.Map map;
        public Food food;
        
        
        public void  MapDraw()
        {
            for (int row = 0; row < map.Height; row++) //Yes, yes, I know,  this is fucking DISASTEROUS! BUT THAT'S ALL BECAUSE OF A FUCKING SHALLOW CLONE! Needs urgent refucktoring!
            {
            for(int col = 0; col < map.Width; col++)
                {
                    map.CurrMapArray[row][col] = map.OrigMapArray[row][col];
                }
            }
          map.CurrMapArray[currPlayer.Y][currPlayer.X] = currPlayer.Character;
            if (currPlayer.Y == food.Y && currPlayer.X == food.X)
            {
                food.FoodTeleport(map);
                currPlayer.Points += food.Value;
            }
            map.CurrMapArray[food.Y][food.X] = food.Character;
          Console.CursorVisible = false;
          for(int i = 0; i < map.Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("\r{0}    ", string.Join("", map.CurrMapArray[i]));


            }
            

        }

        public void PointsShow()
        {
            Console.SetCursorPosition(5, map.Height + 5);
            Console.Write("\r{0}   ", currPlayer.Points.ToString());
        }
    }
}
