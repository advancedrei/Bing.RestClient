﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Bing.Maps;
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
        /// Creates a new instance of the MapsClient.
        /// </summary>
        /// <param name="apiKey">The key registered to a given user to access the Bing APIs.</param>
        /// <param name="culture">The culture code that map data should be localized to. Supported culture codes are listed here: http://msdn.microsoft.com/en-us/library/hh441729.aspx. </param>
        /// <param name="context">A <see cref="UserContext"/> object containing information about the user to refine location results.</param>
        public MapsClient(string apiKey, string culture = "en-US", UserContext context = null)
            : base(apiKey)
        {
            BaseUrl = "https://dev.virtualearth.net/REST/v1/";
            Culture = culture;
            UserContext = context;
        }

        #endregion

        #region Public Methods

        #region CompressPoints

        /// <summary>
        /// Implements the Point Compression Algorithm specified at http://msdn.microsoft.com/en-us/library/jj158958.aspx
        /// </summary>
        /// <param name="points">A List of <see cref="Point">Points</see> to compress.</param>
        /// <returns></returns>
        public string CompressPoints(List<Point> points) 
        {
            int latitude = 0;
            int longitude = 0;
            var result = new StringBuilder(); 

            foreach (var point in points) 
            {

                // step 2
                var newLatitude = Math.Round((decimal)point.Coordinates[0] * 100000);
                var newLongitude = Math.Round((decimal)point.Coordinates[1] * 100000);

                // step 3
                var dy = newLatitude - latitude;
                var dx = newLongitude - longitude;
                latitude = (int)newLatitude;
                longitude = (int)newLongitude;

                // step 4 and 5
                dy = ((int)dy << 1) ^ ((int)dy >> 31);
                dx = ((int)dx << 1) ^ ((int)dx >> 31);

                // step 6
                decimal index = ((dy + dx) * (dy + dx + 1) / 2) + dy;

                while (index > 0) {

                    // step 7
                    var rem = (int)(Convert.ToInt64(index) & 31);
                    index = (index - rem) / 32;

                    // step 8
                    if (index > 0) rem += 32;

                    // step 9
                    result = result.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-"[rem]);
                }
            }

            // step 10
            return result.ToString();
        }

        #endregion

        #region LocationQuery

        /// <summary>
        /// Get a location by specifying values such as a locality, postal code, and street address.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="maxResults">Specifies the maximum number of locations to return in the response.</param>
        /// <param name="includeNeighborhood">Specifies to include the neighborhood in the response when it is available.</param>
        /// <returns>A <see cref="MapsResponse&lt;Location&gt;"/> object with the results from Bing.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MapsResponse<Location>> LocationQuery(Address address, int maxResults = 5, bool includeNeighborhood = true)
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

            return await ExecuteAsync<MapsResponse<Location>>(request);
        }

        /// <summary>
        /// Get an location for a specified point (latitude and longitude).
        /// </summary>
        /// <param name="point">The coordinates of the location that you want to query.</param>
        /// <param name="includeNeighborhood">Specifies to include the neighborhood in the response when it is available.</param>
        /// <returns>A <see cref="MapsResponse&lt;Location&gt;"/> object with the results from Bing.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MapsResponse<Location>> LocationQuery(Point point, bool includeNeighborhood = true)
        {
            if (point == null)
            {
                throw new ArgumentNullException("point", "point cannot be null.");
            }

            var request = new RestRequest("Locations/{point}") { ContentType = ContentTypes.Json };
            request.AddUrlSegment("point", point.ToString());
            request.AddQueryString("inclnb", includeNeighborhood ? 1 : 0);

            PrepRequest(ref request);

            return await ExecuteAsync<MapsResponse<Location>>(request);
        }

        /// <summary>
        /// Get an address for a specified point (latitude and longitude).
        /// </summary>
        /// <param name="latitude">The N-S coordinate for the point in question.</param>
        /// <param name="longitude">The E-W coordinate for the point in question.</param>
        /// <param name="includeNeighborhood">Specifies to include the neighborhood in the response when it is available.</param>
        /// <returns>A <see cref="MapsResponse&lt;Location&gt;"/> object with the results from Bing.</returns>
        public async Task<MapsResponse<Location>> LocationQuery(double latitude, double longitude, bool includeNeighborhood = true)
        {
            var request = new RestRequest("Locations/{latitude},{longitude}") { ContentType = ContentTypes.Json };
            request.AddUrlSegment("latitude", latitude.ToString(NumberFormatInfo.InvariantInfo));
            request.AddUrlSegment("longitude", longitude.ToString(NumberFormatInfo.InvariantInfo));
            request.AddQueryString("inclnb", includeNeighborhood ? 1 : 0);

            PrepRequest(ref request);

            return await ExecuteAsync<MapsResponse<Location>>(request);
        }

        /// <summary>
        /// Get location(s) for a given search term.
        /// </summary>
        /// <param name="query">A string that contains information about a location, such as an address or landmark name.</param>
        /// <param name="maxResults">Specifies the maximum number of locations to return in the response.</param>
        /// <param name="includeNeighborhood">Specifies to include the neighborhood in the response when it is available.</param>
        /// <returns>A <see cref="MapsResponse&lt;Location&gt;"/> object with the results from Bing.</returns>
        /// <remarks>
        /// The strings "Space Needle" (a landmark) and "1 Microsoft Way Redmond WA" (an address) are examples of query strings with 
        /// location information.
        /// </remarks>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MapsResponse<Location>> LocationQuery(string query, int maxResults = 5, bool includeNeighborhood = true)
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

            return await ExecuteAsync<MapsResponse<Location>>(request);
        }

        #endregion



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
