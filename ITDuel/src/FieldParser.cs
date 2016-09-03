using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.FourColors
{
    public static class FieldParser
    {
        private static void ProcessCell(int[,] field, int row, int col, Region region, IList<Region> result)
        {
            if
                ((row < 0) || (row >= field.GetLength(0))
                || ((col < 0) || (col >= field.GetLength(1))))
                return;

            var neighbourId = field[row, col];
            if (region.RegionID == neighbourId)
                return;

            var neighbour = result.FirstOrDefault(x => x.RegionID == neighbourId);

            if ((neighbour != null) && (region.Neighbours.IndexOf(neighbour) == -1))
            {
                region.Neighbours.Add(neighbour);
                
                if (neighbour.Neighbours.IndexOf(region) == -1)
                {
                    neighbour.Neighbours.Add(region);
                }
            }
            
        }

        public static IList<Region> Parse(int[,] field)
        {

            var result = new List<Region>();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    var regionId = field[i, j];

                    var region = result.FirstOrDefault(x => x.RegionID == regionId);
                    if (region == null)
                    {
                        region = new Region()
                        {
                            RegionID = regionId,
                            Neighbours = new List<Region>(),
                            Size = 1
                        };

                        result.Add(region);
                    }
                    else
                    {
                        region.Size++;
                    }

                    ProcessCell(field, i - 1, j, region, result);
                    ProcessCell(field, i - 1, j + 1, region, result);
                    ProcessCell(field, i, j - 1, region, result);
                    ProcessCell(field, i, j + 1, region, result);
                    ProcessCell(field, i + 1, j, region, result);
                    ProcessCell(field, i + 1, j + 1, region, result);
                }
            }
            return result;
        }
    }
}
