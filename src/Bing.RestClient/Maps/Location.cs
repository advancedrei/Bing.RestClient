using System.Runtime.Serialization;

namespace Bing.Maps
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/search/local/ws/rest/v1")]
    public class Location : Resource
    {

        /// <summary>
        /// The name of the resource.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// The latitude and longitude coordinates of the location. 
        /// </summary>
        [DataMember(Name = "point", EmitDefaultValue = false)]
        public Point Point { get; set; }

        /// <summary>
        /// The classification of the geographic entity returned, such as Address.
        /// </summary>
        [DataMember(Name = "entityType", EmitDefaultValue = false)]
        public string EntityType { get; set; }

        /// <summary>
        /// The postal address for the location. An address can contain AddressLine, Neighborhood, Locality, 
        /// AdminDistrict, AdminDistrict2, CountryRegion, FormattedAddress, PostalCode, and Landmark fields. 
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public Address Address { get; set; }

        /// <summary>
        /// The level of confidence that the geocoded location result is a match. Use this value with the match code 
        /// to determine for more complete information about the match. 
        /// </summary>
        [DataMember(Name = "confidence", EmitDefaultValue = false)]
        public string Confidence { get; set; }

        /// <summary>
        /// The level of confidence that the geocoded location result is a match. Use this value with the match code to 
        /// determine for more complete information about the match. 
        /// </summary>
        /// <remarks>
        /// For example, a geocoded location with match codes of Good and Ambiguous means that more than one geocode location 
        /// was found for the location information and that the geocode service did not have search up-hierarchy to find a match. 
        /// <para>
        /// Similarly, a geocoded location with match codes of Ambiguous and UpHierarchy means that a geocode location could not 
        /// be found that matched all of the location information, so the geocode service had to search up-hierarchy and found 
        /// multiple matches at that level. An example of up an Ambiguous and UpHierarchy result is when you provide complete 
        /// address information, but the geocode service cannot locate a match for the street address and instead returns 
        /// information for more than one RoadBlock value.
        /// </para>
        /// </remarks>
        [DataMember(Name = "matchCodes", EmitDefaultValue = false)]
        public string[] MatchCodes { get; set; }

        /// <summary>
        /// A collection of geocoded points that differ in how they were calculated and their suggested use.
        /// </summary>
        [DataMember(Name = "geocodePoints", EmitDefaultValue = false)]
        public Point[] GeocodePoints { get; set; }
    }
}