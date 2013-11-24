using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract]
    public class Hint
    {
        [DataMember(Name = "hintType", EmitDefaultValue = false)]
        public string HintType { get; set; }

        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }
    }
}