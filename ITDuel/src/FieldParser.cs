using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.FourColors
{
    public static class FieldParser
    {
        private static void ProcessCell(int[,] field, int row, int col, IList<Region> result)
        {
            if
                ((row < 0) || (row >= field.GetLength(0))
                || ((col < 0) || (col >= field.GetLength(1))))
                return;
        }

        public static IList<Region> Parse(int[,] field)
        {

            var result = new List<Region>();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
//                    ProcessCell(field, i - 1, )
                }
            }
            return result;
        }
    }
}
