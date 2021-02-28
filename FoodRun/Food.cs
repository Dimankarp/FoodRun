using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Food
    {
        public int X;
        public int Y;
        public char Character = '☼';
        public ConsoleColor Color;
        public int Value = 10;

        public void FoodTeleport(Program.Map map)
        {
            Random randomizer = new Random();
            int newX = randomizer.Next(0, map.Width);
            int newY = randomizer.Next(0, map.Height);
            while(map.OrigMapArray[newY][newX] != '*')
            {
                 newX = randomizer.Next(0, map.Width);
                 newY = randomizer.Next(0, map.Height);
            }
            X = newX;
            Y = newY;
        }
    }
}
