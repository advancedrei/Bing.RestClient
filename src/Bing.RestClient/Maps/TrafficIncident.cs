using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract(Namespace = "http://schemas.microsoft.com/search/local/ws/rest/v1")]
    public class TrafficIncident : Resource
    {
        [DataMember(Name = "point", EmitDefaultValue = false)]
        public Point Point { get; set; }

        [DataMember(Name = "congestion", EmitDefaultValue = false)]
        public string Congestion { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "detour", EmitDefaultValue = false)]
        public string Detour { get; set; }

        [DataMember(Name = "start", EmitDefaultValue = false)]
        public string Start { get; set; }

        [DataMember(Name = "end", EmitDefaultValue = false)]
        public string End { get; set; }

        [DataMember(Name = "incidentId", EmitDefaultValue = false)]
        public long IncidentId { get; set; }

        [DataMember(Name = "lane", EmitDefaultValue = false)]
        public string Lane { get; set; }

        [DataMember(Name = "lastModified", EmitDefaultValue = false)]
        public string LastModified { get; set; }

        [DataMember(Name = "roadClosed", EmitDefaultValue = false)]
        public bool RoadClosed { get; set; }

        [DataMember(Name = "severity", EmitDefaultValue = false)]
        public int Severity { get; set; }

        [DataMember(Name = "toPoint", EmitDefaultValue = false)]
        public Point ToPoint { get; set; }

        [DataMember(Name = "locationCodes", EmitDefaultValue = false)]
        public string[] LocationCodes { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public int Type { get; set; }

        [DataMember(Name = "verified", EmitDefaultValue = false)]
        public bool Verified { get; set; }
    }
}