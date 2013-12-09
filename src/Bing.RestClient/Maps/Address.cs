using System.Runtime.Serialization;
using Bing.Core;

namespace Bing.Maps
{

    /// <summary>
    /// Details about a point on the Earth that has additional location information.
    /// </summary>
    [DataContract]
    public class Address : AddressBase
    {

        /// <summary>
        /// A string specifying the complete address. This address may not include the country or region.
        /// </summary>
        [DataMember(Name = "formattedAddress", EmitDefaultValue = false)]
        public string FormattedAddress { get; set; }

        /// <summary>
        /// A string specifying the neighborhood for an address.
        /// </summary>
        [DataMember(Name = "neighborhood", EmitDefaultValue = false)]
        public string Neighborhood { get; set; }

        /// <summary>
        /// A string specifying the name of the landmark when there is a landmark associated with an address.
        /// </summary>
        [DataMember(Name = "landmark", EmitDefaultValue = false)]
        public string Landmark { get; set; }

    }

}