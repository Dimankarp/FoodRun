using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Interface
    {

        private string Logo = @"
  _____               _ ____              
 |  ___|__   ___   __| |  _ \ _   _ _ __  
 | |_ / _ \ / _ \ / _` | |_) | | | | '_ \ 
 |  _| (_) | (_) | (_| |  _ <| |_| | | | |
 |_|  \___/ \___/ \__,_|_| \_\\__,_|_| |_|
                                          ";

        public int  AnswerInterface<T>(string Title, IEnumerable<T> Answers)
        {
            Console.Clear();
            string PadString = "";//Used for Padding in Title Showing

            Console.ForegroundColor = ConsoleColor.Gray;//Logo Showing
            Console.WriteLine(Logo);
            Console.ForegroundColor = ConsoleColor.White;

            int MidTextStart = Console.WindowWidth / 2 - Title.Length / 2;
            Console.CursorLeft = MidTextStart;

            Console.Write("\r{0}", PadString.PadRight(MidTextStart - 1, '-')); //Padding and Writing Title
            PadString = "";
            Console.Write("{0}{1}", Title, PadString.PadRight(Console.WindowWidth - MidTextStart - Title.Length, '-'));

            
           return AnswerChooser(Answers);
        }

        private int AnswerChooser<T>(IEnumerable<T> Answers)
        {
            Console.CursorVisible = false;
            Console.CursorTop += 2;
            int OrigTop = Console.CursorTop;
            string ArrowPointer = "-->";
            int answer = 0;
            while (true)
            {
                for (int i = 0; i < Answers.Count(); i++)
                {
                    Console.SetCursorPosition(0, OrigTop + 2*i);
                    if (answer == i)
                    {
                        Console.Write("\r{0}", ArrowPointer);
                        Console.Write("\x4{0}. {1}      ", i + 1, Answers.ToArray()[i]);
                    }
                    else Console.Write("\x4{0}. {1}      ", i + 1, Answers.ToArray()[i]);
                }

                string key = Console.ReadKey(true).Key.ToString();
                if (key == "W" || key == "UpArrow")
                {
                    if (answer == 0) answer = Answers.Count() - 1;
                    else answer--;
                }
                else if (key == "S" || key == "DownArrow")
                {
                    if (answer == Answers.Count() - 1) answer = 0;
                    else answer++;
                }
                else if (key == "Enter") return answer;
               
            }

        }


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
            Console.SetCursorPosition(0, map.Height + 3);
            Console.Write("Player's Points: {0}   ", player.Points.ToString());
            Console.SetCursorPosition(0, map.Height + 5);
            Console.Write("AI's     Points: {0}   ", ai.Points.ToString());

        }
    }
}
