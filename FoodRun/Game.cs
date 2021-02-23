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
            Food.FoodTeleport(Map);//Initializing  Starting Food Position
            while (true)
            {
                Player.MovementAsync(Map);
                FoodCheck(Player, Food);
                Interf.MapDraw(Map, Player, Food);
                Interf.PointsShow(Map, Player);
            }


        }

        private void FoodCheck(Player player, Food food)
        {
            if (player.Y == food.Y && player.X == food.X)
            {
                food.FoodTeleport(Map);
                player.Points += food.Value;
            }

        }


    
    }
}
