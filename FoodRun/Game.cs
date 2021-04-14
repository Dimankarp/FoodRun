using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners
{
    class Game
    {
        public Program.Map Map;
        public Player Player;
        public int MaxPts;
        private AI ai;
        private bool Paused = false;


        public Game(Program.Map map, Player player, int PointsGoal = 0)
        {
            Map = map;
            Player = player;
            MaxPts = PointsGoal;
        }

        public void Start(int AIDifficulty = 1)
        {
            Console.Clear();
            Food Food = new Food();
            ai = new AI();
            ai.MovementTime *= AIDifficulty;
            Food.FoodTeleport(Map);//Initializing  Starting Food Position
            Player.Pause += Pause;
            while (true)
            {
                ai.AIMovement(Map, Food);
                Player.MovementAsync(Map);
                FoodCheck(Player, Food, ai);

                Interface.MapDraw(Map, Player, Food, ai);

                Interface.PointsShow(Map, Player, ai, MaxPts);
                Interface.PauseTextToggle(Map, Paused);
            }


        }

        private void FoodCheck(Player player, Food food, AI ai)
        {
            if (player.Y == food.Y && player.X == food.X)
            {
                //Console.Beep(450,20); -Uncomment, when mute button is added. Sounds Plausable, though.
                food.FoodTeleport(Map);
                player.Points += food.Value;
            }
            else if (ai.Y == food.Y && ai.X == food.X)
            {
                food.FoodTeleport(Map);
                ai.Points += food.Value;
            }
            WinningCheck(player, ai);
        }

        private void WinningCheck(Player player, AI oldAI)
        {
            if (MaxPts != 0 && (player.Points >= MaxPts || oldAI.Points >= MaxPts))
            {
                Paused = true;
                ai.Paused = true;
                if (player.Points >= MaxPts)
                {
                    string WinningTextPlayer = "The Player has won the game. Glory to the Sinful One!";
                    string[] Options = { "Get boiled alive by the Satan." };
                    if (Interface.AnswerInterface(WinningTextPlayer, Options) == 0) System.Environment.Exit(0); //Yes, that's brutal!
                }
                else
                {
                    string WinningTextAI = "The AI has won the game. Glory to the Machine!";
                    string[] Options = { "Get sacrificed to the AI." };
                    if (Interface.AnswerInterface(WinningTextAI, Options) == 0) System.Environment.Exit(0); //Yes, even more brutal!
                }
            }
            else return;

        }

        private void Pause()
        {
            if (!Paused)
            {
                Paused = true;
                Player.ControlsEnabled = false;
                ai.Paused = true;
            }
            else
            {
                Paused = false;
                Player.ControlsEnabled = true;
                ai.Paused = false;
            }
        }

    }
}
