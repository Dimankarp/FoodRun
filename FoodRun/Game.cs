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


        public Game(Program.Map map, Player player)
        {
            Map = map;
            Player = player;
        }

        public void Start()
        {
            Interface Interf = new Interface();
            Food Food = new Food();
            AI ai = new AI();
            Food.FoodTeleport(Map);//Initializing  Starting Food Position
            while (true)
            {
                ai.AIMovement(Map, Food);
                Player.MovementAsync(Map);
                FoodCheck(Player, Food, ai);
                Interf.MapDraw(Map, Player, Food, ai);
                Interf.PointsShow(Map, Player, ai);
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
        }

    }
}
