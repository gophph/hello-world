using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.FourColors
{
    static class Helper
    {
        public static IList<Game> Games;
        
        public static Game CreateGameFromJson(string json)
        {
            if (Games == null)
                Games = new List<Game>();

            Game game = new Game();

            

            JObject jfull = JObject.Parse(json);

            game.GameId = jfull["id"].Value<string>();

            JObject j = (JObject)jfull["board"];

            int height = (int)j["height"];
            int width = (int)j["width"];

            int[,] array = new int[height, width];

            JArray arr = (JArray)j["cells"];

            int i = 0;
            int k = 0;
            foreach (JArray arr2 in arr)
            {

                k = 0;
                foreach (int n in arr2)
                {
                    array[i, k] = n;
                    if (n > game.MaxId)
                        game.MaxId = n;
                    k++;
                }
                i++;
            }


            game.regions = FieldParser.Parse(array);


            game.array = array;

            Games.Add(game);

            return game;
        }
    }
}
