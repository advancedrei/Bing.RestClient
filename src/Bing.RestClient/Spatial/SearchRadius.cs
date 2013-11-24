using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bing.Spatial
{
    public class SearchRadius
    {

        public double Latitude { get; set; }


        public double Longitude { get; set; }


        public double Distance { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", Latitude, Longitude, Distance);
        }

    }
}
