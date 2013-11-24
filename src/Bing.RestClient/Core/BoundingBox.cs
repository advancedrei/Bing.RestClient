using System.Runtime.Serialization;

namespace Bing.Core
{
    [DataContract]
    public class BoundingBox
    {
        [DataMember(Name = "southLatitude", EmitDefaultValue = false)]
        public double SouthLatitude { get; set; }

        [DataMember(Name = "westLongitude", EmitDefaultValue = false)]
        public double WestLongitude { get; set; }

        [DataMember(Name = "northLatitude", EmitDefaultValue = false)]
        public double NorthLatitude { get; set; }

        [DataMember(Name = "eastLongitude", EmitDefaultValue = false)]
        public double EastLongitude { get; set; }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", SouthLatitude, WestLongitude, NorthLatitude, EastLongitude);
        }
    }
}