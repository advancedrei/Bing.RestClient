using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract]
    public class Instruction
    {
        [DataMember(Name = "maneuverType", EmitDefaultValue = false)]
        public string ManeuverType { get; set; }

        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }
    }
}