using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRunners.Multiplayer
{
    class MultiplayerGame
    {

        public Program.Map Map { get; set; }
        public List<Player> Players { get; set; }
        public bool Paused { get; set; }
        public Food food;

        [Serializable]
        public class GameInfo
        {
            public Program.Map Map { get; set; }
            public List<Player> Players { get; set; }
            public Food Food { get; set; }
            public bool Paused { get; set; }
        }

        public async void StartAsync()
        {
            await Task.Run(() => Start());
        }

        public void Start()
        {
            food = new Food();
            food.FoodTeleport(Map);
            while (true)
            {
                GlobalFoodCheck(Players, food);
                Interface.MultiplayerMapDraw(Map, Players, food);
                Interface.MultiplayerShowPoints(Map, Players);
            }


        }

        private void GlobalFoodCheck(List<Player> players, Food food)
        {
            foreach (Player item in players)
            {
                if (item.Y == food.Y && item.X == food.X)
                {
                    //Console.Beep(450,20); -Uncomment, when mute button is added. Sounds Plausable, though.
                    food.FoodTeleport(Map);
                    item.Points += food.Value;
                    break;
                }
            }
        }

        public GameInfo GetGameInfo()
        {
            return new GameInfo()
            {
                Map = Map,
                Players = Players,
                Paused = Paused,
                Food = food
            };
        }



    }
}
