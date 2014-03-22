using System.Collections.Generic;
using System.Linq;

namespace Bing.Spatial
{

    /// <summary>
    /// 
    /// </summary>
    public static class ListExtensions
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static string ToJsonArray(this List<PoiEntityTypes> points)
        {
            return points.Aggregate("[", (current, next) => string.Format("{0},\"{1}\"", current, (int) next)) + "]";
        }


    }
}