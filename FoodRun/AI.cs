using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FoodRunners
{
    class AI
    {
        public int X = 4;
        public int Y = 4;
        public char Character = 'A';
        public ConsoleColor Color;
        public int Points;
        private Stack<int[]> CurrPath = new Stack<int[]>();
        private int LastFoodX;
        private int LastFoodY;
        private string[][] ValueMap;

        public async void MovementAsync(Program.Map map, Food food)
        {
            await Task.Run(() => AIMovement(map, food));
        }
        private void AIMovement(Program.Map map, Food food)
        {
         if(food.X != LastFoodX || food.Y != LastFoodY) //Recalculating path
            {
                LastFoodX = food.X;
                LastFoodY = food.Y;
                // ValueMap = map.OrigMapArray.Select(a => (string[])a.Clone()).ToArray();
                ValueMap = new string[map.Height][];
                for(int row = 0; row < map.Height; row++)
                {
                    ValueMap[row] = new string[map.Width];
                    for(int col = 0; col < map.Width; col++)
                    {
                        ValueMap[row][col] = map.OrigMapArray[row][col].ToString();
                    }

                }
                CurrPath.Clear();
                MapEvaluator(X, Y, 0);
                PathBuilder(LastFoodX, LastFoodY);
            }
            if (CurrPath.Count != 0)
            {
                int[] Coords = CurrPath.Pop();
                X = Coords[0];
                Y = Coords[1];
            }
        }

        private bool MapEvaluator(int startX, int startY, int Value) //Yes, I know that many args don't match the standart...but who cares?!
        {
            bool Found = false;
            if (startX == LastFoodX && startY == LastFoodY) return true;
            ValueMap[startY][startX] = Value.ToString();
            if (ValueMap[startY + 1][startX] == "*") Found = MapEvaluator(startX, startY + 1, Value + 1);
            if (ValueMap[startY][startX + 1] == "*") Found = MapEvaluator(startX + 1, startY, Value + 1);
            if (ValueMap[startY - 1][startX] == "*") Found = MapEvaluator(startX, startY - 1, Value + 1);
            if (ValueMap[startY][startX - 1] == "*") Found = MapEvaluator(startX - 1, startY, Value + 1);

            return Found;
        }

        private void PathBuilder(int curX, int curY)
        {
            if (X == curX && Y == curY) return;
            int[] Coords = { curX, curY };
            CurrPath.Push(Coords);
            List<int> mins = new List<int>();
            int min;
            if (Int32.TryParse(ValueMap[curY + 1][curX], out min)) mins.Add(min);
            if (Int32.TryParse(ValueMap[curY][curX + 1], out min)) mins.Add(min);
            if (Int32.TryParse(ValueMap[curY - 1][curX], out min)) mins.Add(min);
            if (Int32.TryParse(ValueMap[curY][curX - 1], out min)) mins.Add(min);
            min = mins.Min();
            int temp;
            if (Int32.TryParse(ValueMap[curY + 1][curX], out temp)){
                if (temp == min)
                {
                    PathBuilder(curX, curY + 1);
                    return;
                }
            }

            if (Int32.TryParse(ValueMap[curY][curX + 1], out temp)){
                if (temp == min)
                {
                    PathBuilder(curX + 1, curY);
                    return;
                }
            }

            if (Int32.TryParse(ValueMap[curY - 1][curX], out temp)){
                if (temp == min)
                {
                    PathBuilder(curX, curY - 1);
                    return;
                }
            }

            if (Int32.TryParse(ValueMap[curY][curX - 1], out temp)){
                if (temp == min)
                {
                    PathBuilder(curX - 1, curY);
                    return;
                }
            }


        }





    }
}
