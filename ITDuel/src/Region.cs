using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nancy.FourColors
{
    public class Region
    {
        public IList<Region> Neighbours { get; set; }
        public int RegionID { get; set; }
        public int? Color { get; set; }
        public int Size { get; set; }
    }
}
