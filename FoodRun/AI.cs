using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FoodRunners
{
    class AI
    {
        public int X = 4;
        public int Y = 4;
        public char Character = '☺';
        public ConsoleColor Color;
        public int Points;
        private Stack<int[]> CurrPath = new Stack<int[]>();
        private int LastFoodX;
        private int LastFoodY;
        private string[][] ValueMap;
        private Stopwatch Watch = new Stopwatch();
        public async void MovementAsync(Program.Map map, Food food)
        {
            await Task.Run(() => AIMovement(map, food));
        }
        public void AIMovement(Program.Map map, Food food)
        {
            if (food.X != LastFoodX || food.Y != LastFoodY) //Recalculating path
            {
                LastFoodX = food.X;
                LastFoodY = food.Y;
                ValueMap = new string[map.Height][];
                for (int row = 0; row < map.Height; row++)
                {
                    ValueMap[row] = new string[map.Width];
                    for (int col = 0; col < map.Width; col++)
                    {
                        ValueMap[row][col] = map.OrigMapArray[row][col].ToString();
                    }

                }
                CurrPath.Clear();
                MapEvaluator();
                PathBuilder(LastFoodX, LastFoodY);
            }
            if (CurrPath.Count != 0 && (Watch.IsRunning==false || Watch.ElapsedMilliseconds > 200)) //The less the number, the faster an AI is
            {
                Watch.Restart();
                int[] Coords = CurrPath.Pop();
                X = Coords[0];
                Y = Coords[1];
            }
        }

        private void MapEvaluator()
        {
            Queue<int[]> Coords = new Queue<int[]>();
            int[] currCords = { X, Y, 0};
            Coords.Enqueue(currCords);
            while (Coords.Count > 0)
            {
                int[] Current = Coords.Dequeue();
                ValueMap[Current[1]][Current[0]] = Current[2].ToString();//Yeah, I know, that's a mess...but who cares?!
                if (ValueMap[Current[1] + 1][Current[0]] == "*")
                {
                    int[] newCords = {Current[0], Current[1] + 1, Current[2] + 1 };
                    Coords.Enqueue(newCords);
                }
                if (ValueMap[Current[1]][Current[0]+1] == "*")
                {
                    int[] newCords = { Current[0]+1, Current[1], Current[2] + 1 };
                    Coords.Enqueue(newCords);
                }
                if (ValueMap[Current[1] - 1][Current[0]] == "*")
                {
                    int[] newCords = { Current[0], Current[1] - 1, Current[2] + 1 };
                    Coords.Enqueue(newCords);
                }
                if (ValueMap[Current[1]][Current[0] - 1] == "*")
                {
                    int[] newCords = { Current[0] - 1, Current[1], Current[2] + 1 };
                    Coords.Enqueue(newCords);
                }
            }
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

        public void MapHotness()//Shows the ValueMap(each cell has it's own value based on distance from  AI's X,Y)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < ValueMap.Length; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("\r{0}    ", string.Join(" ", ValueMap[i]));


            }

        }





    }
}
