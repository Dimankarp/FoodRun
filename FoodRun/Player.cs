using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Player
    {
        public int X = 1;
        public int Y = 1;
        public char Character = 'P';
        public ConsoleColor Color;
        public int Points;

        public async void MovementAsync(Program.Map map)
        {
            await Task.Run(() => PlayerMovement(map));
        }
        private void PlayerMovement(Program.Map map)
        {
            string key = Console.ReadKey(true).Key.ToString();
            if (key == "W" || key == "UpArrow")
            {
                if (map.OrigMapArray[Y - 1][X] != '#') Y--;
            }
           else if (key == "S" || key == "DownArrow")
            {
                if (map.OrigMapArray[Y + 1][X] != '#') Y++;
            }
            else if (key == "A" || key == "LeftArrow")
            {
                if (map.OrigMapArray[Y][X-1] != '#') X--;
            }
            else if (key == "D" || key == "RightArrow")
            {
                if (map.OrigMapArray[Y][X+1] != '#') X++;
            }

        }

    }
}
