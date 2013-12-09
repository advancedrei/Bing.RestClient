using System.Runtime.Serialization;

namespace Bing.Maps
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [KnownType(typeof(Location))]
    [KnownType(typeof(Route))]
    [KnownType(typeof(TrafficIncident))]
    [KnownType(typeof(ImageryMetadata))]
    [KnownType(typeof(ElevationData))]
    [KnownType(typeof(SeaLevelData))]
    [KnownType(typeof(CompressedPointList))]
    public class Resource
    {


        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "bbox", EmitDefaultValue = false)]
        public double[] BoundingBox { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "__type", EmitDefaultValue = false)]
        public string Type { get; set; }
    }

}