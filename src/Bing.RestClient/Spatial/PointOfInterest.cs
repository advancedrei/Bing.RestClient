using System.Runtime.Serialization;
using Bing.Core;

namespace Bing.Spatial
{


    [DataContract(Name = "d", Namespace = "")]
    public class PointOfInterest
    {

        [DataMember(Name = "EntityID")]
        public string EntityId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public string AddressLine { get; set; }

        [DataMember]
        public string Locality { get; set; }

        [DataMember]
        public string AdminDistrict { get; set; }

        [DataMember]
        public string AdminDistrict2 { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string CountryRegion { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember(Name = "EntityTypeID")]
        public string EntityTypeId { get; set; }


    }
}
