using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Bing.Maps;
using Bing.Maps;
using Bing.Spatial;
using PortableRest;

namespace Bing
{
    /// <summary>
    /// The Bing™ Maps REST Services Application Programming Interface (API) provides a 
    /// Representational State Transfer (REST) interface to perform tasks such as creating a static map 
    /// with pushpins, geocoding an address, retrieving imagery metadata, or creating a route.
    /// </summary>
    public class MapsClient : BingClientBase
    {

        #region Public Properties

        /// <summary>
        /// For supported cultures, street names are localized to the local culture. For example, if you request a 
        /// location in France, the street names are localized in French. For other localized data such as country 
        /// names, the level of localization will vary for each culture. For example, there may not be a localized 
        /// name for the "United States" for every culture code.
        /// </summary>
        public string Culture { get; private set; }

        /// <summary>
        /// Use user context parameters to specify information about the user. You can increase the accuracy of a 
        /// location result when you specify a user context parameter in your request URL.
        /// </summary>
        public UserContext UserContext { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="culture"></param>
        /// <param name="context"></param>
        public MapsClient(string apiKey, string culture = "en-US", UserContext context = null) : base(apiKey)
        {
            BaseUrl = "https://dev.virtualearth.net/REST/v1/";
            Culture = culture;
            UserContext = context;
        }

        #endregion

        #region Query

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="maxResults"></param>
        /// <param name="includeNeighborhood">Specifies to include the neighborhood in the response when it is available.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MapsResponse> Query(Address address, int maxResults = 5, bool includeNeighborhood = true)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address", "The address cannot be null.");
            }
            
            var request = new RestRequest("Locations") { ContentType = ContentTypes.Json };
            
            if (!string.IsNullOrWhiteSpace(address.AdminDistrict))
            {
                request.AddQueryString("adminDistrict", address.AdminDistrict);
            }
            if (!string.IsNullOrWhiteSpace(address.Locality))
            {
                request.AddQueryString("locality", address.Locality);
            }
            if (!string.IsNullOrWhiteSpace(address.PostalCode))
            {
                request.AddQueryString("postalCode", address.PostalCode);
            }
            if (!string.IsNullOrWhiteSpace(address.AddressLine))
            {
                request.AddQueryString("addressLine", address.AddressLine);
            }
            if (!string.IsNullOrWhiteSpace(address.CountryRegion))
            {
                request.AddQueryString("countryRegion", address.CountryRegion);
            }
            if (maxResults != 5)
            {
                request.AddQueryString("maxRes", maxResults);
            }
            request.AddQueryString("inclnb", includeNeighborhood ? 1 : 0);

            PrepRequest(ref request);

            return await ExecuteAsync<MapsResponse>(request);
        }

        /// <summary>
        /// Get an address for a specified point (latitude and longitude).
        /// </summary>
        /// <param name="point">The coordinates of the location that you want to reverse geocode.</param>
        /// <param name="includeNeighborhood">Specifies to include the neighborhood in the response when it is available.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MapsResponse> Query(Point point, bool includeNeighborhood = true)
        {
            if (point == null)
            {
                throw new ArgumentNullException("point", "point cannot be null.");
            }

            var request = new RestRequest("Locations/{point}") { ContentType = ContentTypes.Json };
            request.AddUrlSegment("point", point.ToString());
            request.AddQueryString("inclnb", includeNeighborhood ? 1 : 0);

            PrepRequest(ref request);

            return await ExecuteAsync<MapsResponse>(request);
        }

        /// <summary>
        /// Get an address for a specified point (latitude and longitude).
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="includeNeighborhood">Specifies to include the neighborhood in the response when it is available.</param>
        /// <returns></returns>
        public async Task<MapsResponse> Query(double latitude, double longitude, bool includeNeighborhood = true)
        {
            var request = new RestRequest("Locations/{latitude},{longitude}") { ContentType = ContentTypes.Json };
            request.AddUrlSegment("latitude", latitude.ToString());
            request.AddUrlSegment("longitude", longitude.ToString());
            request.AddQueryString("inclnb", includeNeighborhood ? 1 : 0);

            PrepRequest(ref request);

            return await ExecuteAsync<MapsResponse>(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="maxResults"></param>
        /// <param name="includeNeighborhood">Specifies to include the neighborhood in the response when it is available.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MapsResponse> Query(string query, int maxResults = 5, bool includeNeighborhood = true)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException("query", "The query cannot be null.");
            }

            var request = new RestRequest("Locations/{query}") { ContentType = ContentTypes.Json };
            request.AddUrlSegment("query", query.Replace("\n", ", "));

            if (maxResults != 5)
            {
                request.AddQueryString("maxRes", maxResults);
            }
            request.AddQueryString("inclnb", includeNeighborhood ? 1 : 0);

            PrepRequest(ref request);

            return await ExecuteAsync<MapsResponse>(request);
        }

        #endregion

        #region Private Members

        private void PrepRequest(ref RestRequest request)
        {
            request.AddQueryString("o", "json");
            request.AddQueryString("key", ApiKey);

            if (!string.IsNullOrEmpty(Culture))
                request.AddQueryString("c", Culture);

            if (UserContext == null) return;
            if (!string.IsNullOrEmpty(UserContext.IpAddress))
                request.AddQueryString("ip", UserContext.IpAddress);

            if (UserContext.Location != null)
                request.AddQueryString("ul", string.Format("{0},{1}", UserContext.Location.Coordinates[0], UserContext.Location.Coordinates[1]));

            if (UserContext.MapView != null)
                request.AddQueryString("umv", UserContext.MapView.ToString());
        }

        #endregion

    }
}
