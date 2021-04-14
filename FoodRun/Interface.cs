using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    static class Interface
    {
        private static string Logo = @"
  _____               _ ____              
 |  ___|__   ___   __| |  _ \ _   _ _ __  
 | |_ / _ \ / _ \ / _` | |_) | | | | '_ \ 
 |  _| (_) | (_) | (_| |  _ <| |_| | | | |
 |_|  \___/ \___/ \__,_|_| \_\\__,_|_| |_|
                                          ";

        public static int AnswerInterface<T>(string Title, IEnumerable<T> Answers, int StartPos = 0)
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


            return AnswerChooser(Answers, StartPos);
        }

        private static int AnswerChooser<T>(IEnumerable<T> Answers, int StartPos = 0)
        {
            Console.CursorVisible = false;
            Console.CursorTop += 2;
            int OrigTop = Console.CursorTop;
            string ArrowPointer = "-->";
            int answer = StartPos;
            while (true)
            {
                for (int i = 0; i < Answers.Count(); i++)
                {
                    Console.SetCursorPosition(0, OrigTop + 2 * i);
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


        public static bool GetIPAndPort<T>(IEnumerable<T> Answers, int AnswerIndex, out string[] Data)//Returns true if checking was successful, otherwise -  false
        {
            Data = new string[2];
            string UserInput = UserInputInterface(Answers, AnswerIndex);

            if (!UserInput.Contains(':'))
            {
                ErrorMessageShow(Answers, AnswerIndex, "Please, enter an IpAdress in format - IpAdress:Port");
                return false;
            }

            UserInput.Trim();
            Data = UserInput.Split(':');

            if (!Data[0].Contains('.'))
            {
                ErrorMessageShow(Answers, AnswerIndex, "Please, enter an IpAdress in format - A.B.C.D");
                return false;
            }

            string[] IpNumbers = Data[0].Split('.');

            if (IpNumbers.Length != 4)
            {
                ErrorMessageShow(Answers, AnswerIndex, "Please, enter an IpAdress in format - A.B.C.D");
                return false;
            }

            foreach (string item in IpNumbers)
            {
                int num;
                if (!int.TryParse(item, out num) || num < 0 || num > 255)
                {
                    ErrorMessageShow(Answers, AnswerIndex, "Please, enter an IpAdress using numbers from 0 to 255");
                    return false;
                }
            }
            int port;
            if (!int.TryParse(Data[1], out port) || port < 1 || port > 65535)
            {
                ErrorMessageShow(Answers, AnswerIndex, "Please, enter an Port using numbers from 1 to 65535");
                return false;
            }
            return true;
        }

        private static void ErrorMessageShow<T>(IEnumerable<T> Answers, int AnswerIndex, string message)
        {
            int CursorLeft = Answers.ToArray()[AnswerIndex].ToString().Length + 7;
            Console.SetCursorPosition(CursorLeft + 1, 9 + AnswerIndex * 2);
            ClearLine(CursorLeft + 1);
            Console.Write(message);
            Console.ReadKey(true);
            ClearLine(CursorLeft + 1);
        }



        private static string UserInputInterface<T>(IEnumerable<T> Answers, int AnswerIndex)
        {
            int CursorLeft = Answers.ToArray()[AnswerIndex].ToString().Length + 7;
            Console.SetCursorPosition(CursorLeft, 9 + AnswerIndex * 2);//9 is a row, where the first button is located
            ClearLine(CursorLeft);

            Console.Write(":");

            string UserInput = Console.ReadLine();
            Console.CursorTop -= 1;
            ClearLine(CursorLeft);

            return UserInput;
        }


        public static void MapDraw(Program.Map map, Player player, Food food, AI computer)
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

        public static void PointsShow(Program.Map map, Player player, AI ai, int MaxPoints = 0)
        {
            if (MaxPoints == 0)
            {
                Console.SetCursorPosition(0, map.Height + 3);
                Console.Write("Player's Points: {0}   ", player.Points.ToString());
                Console.SetCursorPosition(0, map.Height + 5);
                Console.Write("AI's     Points: {0}   ", ai.Points.ToString());
            }
            else
            {
                Console.SetCursorPosition(0, map.Height + 3);
                Console.Write("Player's Points: {0}/{1}   ", player.Points.ToString(), MaxPoints);
                Console.SetCursorPosition(0, map.Height + 5);
                Console.Write("AI's     Points: {0}/{1}  ", ai.Points.ToString(), MaxPoints);
            }

        }

        public static void PauseTextToggle(Program.Map map, bool state = true)
        {
            if (state)
            {
                string Text = "THE GAME IS PAUSED. PRESS 'ESC' OR 'P' TO UNPAUSE";
                int MidTextStart = Console.WindowWidth / 2 - Text.Length / 2;
                Console.CursorLeft = MidTextStart;
                Console.SetCursorPosition(MidTextStart, map.Height + 7);
                Console.Write(Text);
            }
            else
            {
                Console.CursorTop = map.Height + 7;
                ClearLine();

            }
        }

        public static void MultiplayerMapDraw(Program.Map map, List<Player> players, Food food)
        {
            map.CurrMapArray = map.OrigMapArray.Select(a => (char[])a.Clone()).ToArray();
            foreach (Player player in players)
            {
                map.CurrMapArray[player.Y][player.X] = player.Character;
            }
            map.CurrMapArray[food.Y][food.X] = food.Character;
            Console.CursorVisible = false;
            for (int i = 0; i < map.Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("\r{0}    ", string.Join(" ", map.CurrMapArray[i]));


            }
        }

        public static void MultiplayerShowPoints(Program.Map map, List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.SetCursorPosition(0, map.Height + i * 2 + 1);
                Console.Write(" |{0}|'s Points: {1}   ", players[i].Character, players[i].Points.ToString());
            }
        }


        public static void ClearLine(int CursorLeft = 0)
        {
            Console.SetCursorPosition(CursorLeft, Console.CursorTop);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(CursorLeft, Console.CursorTop - 1);
        }
    }
}

