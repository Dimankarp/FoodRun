using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Interface
    {

        public void MapDraw(Program.Map map, Player player, Food food, AI computer)
        {
            map.CurrMapArray = map.OrigMapArray.Select(a => (char[])a.Clone()).ToArray();
            map.CurrMapArray[computer.Y][computer.X] = computer.Character;
            map.CurrMapArray[player.Y][player.X] = player.Character;
            map.CurrMapArray[food.Y][food.X] = food.Character;
            Console.CursorVisible = false;
            for (int i = 0; i < map.Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("\r{0}    ", string.Join(" ", map.CurrMapArray[i]));


            }

        }

        public void PointsShow(Program.Map map, Player player, AI ai)
        {
            Console.SetCursorPosition(5, map.Height + 5);
            Console.Write("\r{0}   ", player.Points.ToString());
            Console.SetCursorPosition(5, map.Height + 6);
            Console.Write("\r{0}   ", ai.Points.ToString());

        }
    }
}
