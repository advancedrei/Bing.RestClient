using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract]
    public class Warning
    {
        [DataMember(Name = "warningType", EmitDefaultValue = false)]
        public string WarningType { get; set; }

        [DataMember(Name = "severity", EmitDefaultValue = false)]
        public string Severity { get; set; }

        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }
    }
}