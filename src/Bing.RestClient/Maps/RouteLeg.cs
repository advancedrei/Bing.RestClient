using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract]
    public class RouteLeg
    {
        [DataMember(Name = "travelDistance", EmitDefaultValue = false)]
        public double TravelDistance { get; set; }

        [DataMember(Name = "travelDuration", EmitDefaultValue = false)]
        public double TravelDuration { get; set; }

        [DataMember(Name = "actualStart", EmitDefaultValue = false)]
        public Point ActualStart { get; set; }

        [DataMember(Name = "actualEnd", EmitDefaultValue = false)]
        public Point ActualEnd { get; set; }

        [DataMember(Name = "startLocation", EmitDefaultValue = false)]
        public Location StartLocation { get; set; }

        [DataMember(Name = "endLocation", EmitDefaultValue = false)]
        public Location EndLocation { get; set; }

        [DataMember(Name = "itineraryItems", EmitDefaultValue = false)]
        public ItineraryItem[] ItineraryItems { get; set; }
    }
}