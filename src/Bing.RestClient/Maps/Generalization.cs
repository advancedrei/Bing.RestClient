using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract]
    public class Generalization
    {
        [DataMember(Name = "pathIndices", EmitDefaultValue = false)]
        public int[] PathIndices { get; set; }

        [DataMember(Name = "latLongTolerance", EmitDefaultValue = false)]
        public double LatLongTolerance { get; set; }
    }
}