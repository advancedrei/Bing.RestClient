using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bing.Spatial
{
    internal class SpatialResponseList<T> where T : class
    {

        [DataMember(Name = "results")]
        public List<T> Results { get; set; } 

    }
}