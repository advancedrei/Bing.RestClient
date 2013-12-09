using System.Runtime.Serialization;

namespace Bing.Maps
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [KnownType(typeof(Point))]
    public class Shape
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "boundingBox", EmitDefaultValue = false)]
        public double[] BoundingBox { get; set; }
    }

}