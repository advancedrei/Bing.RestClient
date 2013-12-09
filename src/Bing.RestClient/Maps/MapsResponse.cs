using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace Bing.Maps
{
    /// <summary>
    /// The response to a Bing Maps REST Services URL request includes the status of the request and one or more 
    /// resources that contain location, imagery, or route information. The resource information that is returned 
    /// depends on the Bing Maps REST Services URL that is used and the parameter values that are provided with it. 
    /// For example, a Locations API URL returns one or more Location resources that provide location information 
    /// based on the values in the URL request. 
    /// </summary>
    [DataContract(Name = "response")]
    public class MapsResponse
    {

        #region Properties

        /// <summary>
        /// A copyright notice.
        /// </summary>
        [DataMember(Name = "copyright", EmitDefaultValue = false)]
        public string Copyright { get; set; }

        /// <summary>
        /// A URL that references a brand image to support contractual branding requirements.
        /// </summary>
        [DataMember(Name = "brandLogoUri", EmitDefaultValue = false)]
        public string BrandLogoUri { get; set; }

        /// <summary>
        /// The HTTP Status code for the request.
        /// </summary>
        [DataMember(Name = "statusCode", EmitDefaultValue = false)]
        public int StatusCode { get; set; }

        /// <summary>
        /// A description of the HTTP status code.
        /// </summary>
        [DataMember(Name = "statusDescription", EmitDefaultValue = false)]
        public string StatusDescription { get; set; }

        /// <summary>
        /// A status code that offers additional information about authentication success or failure.
        /// </summary>
        [DataMember(Name = "authenticationResultCode", EmitDefaultValue = false)]
        public string AuthenticationResultCode { get; set; }

        /// <summary>
        /// A collection of error descriptions. For example, ErrorDetails can identify parameter values that are not valid or missing.
        /// </summary>
        [DataMember(Name = "errorDetails", EmitDefaultValue = false)]
        public string[] ErrorDetails { get; set; }

        /// <summary>
        /// A unique identifier for the request.
        /// </summary>
        [DataMember(Name = "traceId", EmitDefaultValue = false)]
        public string TraceId { get; set; }

        /// <summary>
        /// A collection of ResourceSet objects. A ResourceSet is a container of Resources returned by the request.
        /// </summary>
        [DataMember(Name = "resourceSets", EmitDefaultValue = false)]
        public List<ResourceSet> ResourceSets { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Address> GetAddresses()
        {
            return GetLocations().Select(c => c.Address).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Point> GetCoordinates()
        {
            return GetLocations().Select(c => c.Point).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Location> GetLocations()
        {
            return (from rs in ResourceSets
                    from r in rs.Resources
                    let location = r as Location
                    where location != null
                    select location).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Address GetFirstAddress()
        {
            return GetAddresses().FirstOrDefault();
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public  string GetFirstAddress(Func<Address, string> selector)
        {
            Debug.Assert(selector != null);
            var address = GetFirstAddress();
            return address != null ? selector(address) : "";
        }

        #endregion

    }
}