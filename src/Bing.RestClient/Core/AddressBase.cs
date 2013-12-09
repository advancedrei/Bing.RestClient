using System.Runtime.Serialization;

namespace Bing.Core
{

    /// <summary>
    /// Details about a point on the Earth that has additional location information.
    /// </summary>
    [DataContract]
    public class AddressBase
    {

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "addressLine", EmitDefaultValue = false)]
        public string AddressLine { get; set; }

        /// <summary>
        /// A string specifying the populated place for the address. </summary>
        /// <remarks>
        /// This typically refers to a city, but may refer to a suburb or a neighborhood in certain countries.
        /// </remarks>
        [DataMember(Name = "locality", EmitDefaultValue = false)]
        public string Locality { get; set; }

        /// <summary>
        /// A string specifying the subdivision name in the country or region for an address. 
        /// </summary>
        /// <remarks>
        /// This element is typically treated as the first order administrative subdivision, 
        /// but in some cases it is the second, third, or fourth order subdivision in a country, 
        /// dependency, or region. 
        /// </remarks>
        [DataMember(Name = "adminDistrict", EmitDefaultValue = false)]
        public string AdminDistrict { get; set; }

        /// <summary>
        /// A string specifying the subdivision name in the country or region for an address. 
        /// </summary>
        /// <remarks>
        /// This element is used when there is another level of subdivision information for a location, such as the county.
        /// </remarks>
        [DataMember(Name = "adminDistrict2", EmitDefaultValue = false)]
        public string AdminDistrict2 { get; set; }

        /// <summary>
        /// A string specifying the post code, postal code, or ZIP Code of an address.
        /// </summary>
        [DataMember(Name = "postalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// A string specifying the country or region name of an address.
        /// </summary>
        [DataMember(Name = "countryRegion", EmitDefaultValue = false)]
        public string CountryRegion { get; set; }


    }

}