using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract(Namespace = "http://schemas.microsoft.com/search/local/ws/rest/v1")]
    public class ElevationData : Resource
    {
        [DataMember(Name = "elevations", EmitDefaultValue = false)]
        public int[] Elevations { get; set; }

        [DataMember(Name = "zoomLevel", EmitDefaultValue = false)]
        public int ZoomLevel { get; set; }
    }
}