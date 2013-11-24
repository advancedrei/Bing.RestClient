using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract]
    [KnownType(typeof(Point))]
    public class Shape
    {
        [DataMember(Name = "boundingBox", EmitDefaultValue = false)]
        public double[] BoundingBox { get; set; }
    }
}