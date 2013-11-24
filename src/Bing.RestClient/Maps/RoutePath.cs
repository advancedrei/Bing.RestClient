using System.Runtime.Serialization;

namespace Bing.Maps
{
    [DataContract]
    public class RoutePath
    {
        [DataMember(Name = "line", EmitDefaultValue = false)]
        public Line Line { get; set; }

        [DataMember(Name = "generalizations", EmitDefaultValue = false)]
        public Generalization[] Generalizations { get; set; }
    }
}