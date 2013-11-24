using System.Runtime.Serialization;
using Bing.Core;

namespace Bing.Maps
{

    [DataContract]
    public class Address : AddressBase
    {

        [DataMember(Name = "formattedAddress", EmitDefaultValue = false)]
        public string FormattedAddress { get; set; }

        [DataMember(Name = "neighborhood", EmitDefaultValue = false)]
        public string Neighborhood { get; set; }

        [DataMember(Name = "landmark", EmitDefaultValue = false)]
        public string Landmark { get; set; }

    }

}