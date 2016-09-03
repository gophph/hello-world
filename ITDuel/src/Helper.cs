using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.FourColors
{
    class Helper
    {
        public static int MaxId;
        public static int[,] GetArrayFromJson(string json)
        {
            JObject jfull = JObject.Parse(json);
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
                    if (n > MaxId)
                        MaxId = n;
                    k++;
                }
                i++;
            }

            return array;
        }
    }
}
