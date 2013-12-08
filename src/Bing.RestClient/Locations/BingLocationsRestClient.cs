using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;

using PortableRest;
using Bing.Maps;

namespace Bing.Locations
{
    public class BingLocationsRestClient : RestClient
    {
        string _apiKey;

        public BingLocationsRestClient(string api_key, string user_agent = "", string culture = "en-US", UserContext context = null)
        {
            BaseUrl = "http://dev.virtualearth.net/REST/v1/";
            UserAgent = user_agent;
            _apiKey = api_key;
            Culture = culture;
            UserContext = context;
        }

        public string Culture { get; private set; }

        public UserContext UserContext { get; private set; }

        public async Task<string> GetAddressPart(double lat, double lon, AddressEntityType entityType)
        {
            return await GetAddressPart(lat, lon, entityType.ToString());
        }

        public async Task<string> GetAddressPart(double lat, double lon, string entityType)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("includeEntityTypes", entityType);
            if (entityType.Equals("Neighborhood", StringComparison.OrdinalIgnoreCase))
                parms.Add("inclnb", "1");

            var result = await Get<Response>(string.Format("Locations/{0},{1}", lat, lon), parms);

            return result.GetFirstAddressPart(entityType);
        }

        public async Task<string> GetFormattedAddress(double lat, double lon)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("includeEntityTypes", "Address,PopulatedPlace,Postcode1,AdminDivision1,CountryRegion");

            var result = await Get<Response>(string.Format("Locations/{0},{1}", lat, lon), parms);

            return result.GetFirstFormattedAddress();
        }

        public async Task<Address> GetAddress(double lat, double lon, bool includeNeighborhood = false)
        {
            var result = await GetGeoCodeResult(lat, lon, includeNeighborhood);

            return result.GetFirstAddress();
        }

        public async Task<Response> GetGeoCodeResult(double lat, double lon, bool includeNeighborhood = false)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("includeEntityTypes", "Address,Neighborhood,PopulatedPlace,Postcode1,AdminDivision1,AdminDivision2,CountryRegion");
            parms.Add("inclnb", includeNeighborhood ? "1" : "0");

            return await Get<Response>(string.Format("Locations/{0},{1}", lat, lon), parms);
        }

        public async Task<Tuple<double, double>> QueryCoordinate(string query, int maxResults = 1)
        {
            var result = await Query(query, maxResults);

            return result.GetFirstCoordinate();
        }

        public async Task<Response> Query(string query, int maxResults = 1)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("q", query.Replace("\n", ", "));
            parms.Add("maxRes", maxResults);

            return await Get<Response>("Locations", parms);
        }

        public async Task<Address> ParseAddress(string address)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("q", address.Replace("\n", ", "));
            parms.Add("maxRes", 1);
            parms.Add("incl", "queryParse");

            var result = await Get<Response>("Locations", parms);
            return result.GetFirstAddress();
        }

        public async Task<Tuple<double, double>> GetCoordinate(string addressLine, string locality, string adminDistrict, string postalCode, string countryRegion, int maxResults = 1)
        {
            var result = await GetGeoCodeResult(addressLine, locality, adminDistrict, postalCode, countryRegion, maxResults);

            return result.GetFirstCoordinate();
        }

        public async Task<Tuple<double, double>> GetCoordinate(string landMark, int maxResults = 1)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("maxRes", maxResults);

            var result = await Get<Response>("Locations/" + landMark, parms);

            return result.GetFirstCoordinate();
        }

        public async Task<Tuple<double, double>> GetCoordinate(Address address, int maxResults = 1)
        {
            var result = await GetGeoCodeResult(address, maxResults);

            return result.GetFirstCoordinate();
        }

        public async Task<Response> GetGeoCodeResult(string addressLine, string locality, string adminDistrict, string postalCode, string countryRegion, int maxResults = 1)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("addressLine", addressLine);
            parms.Add("locality", locality);
            parms.Add("adminDistrict", adminDistrict);
            parms.Add("postalCode", postalCode);
            parms.Add("countryRegion", countryRegion);
            parms.Add("maxRes", maxResults);

            return await Get<Response>("Locations", parms);
        }

        public async Task<Response> GetGeoCodeResult(Address address, int maxResults = 1)
        {
            return await GetGeoCodeResult(address.AddressLine, address.Locality, address.AdminDistrict, address.PostalCode, address.CountryRegion, maxResults);
        }

        private async Task<T> Get<T>(string endPoint, IDictionary<string, object> parms) where T : class
        {
            Debug.Assert(parms != null);

            var request = new RestRequest(endPoint, HttpMethod.Get);
            request.ContentType = ContentTypes.FormUrlEncoded;

            SetAPIParams(request);

            // add each parameter to the query string, ignoring params with null values
            foreach (var kvp in parms.Where(kvp => kvp.Value != null))
                request.AddQueryString(kvp.Key, kvp.Value.ToString());

            return await ExecuteAsync<T>(request);
        }

        private void SetAPIParams(RestRequest request)
        {
            request.AddQueryString("o", "json");
            request.AddQueryString("key", _apiKey);

            if (!string.IsNullOrEmpty(Culture))
                request.AddQueryString("c", Culture);

            if (UserContext != null)
            {
                if (!string.IsNullOrEmpty(UserContext.IPAddress))
                    request.AddQueryString("ip", UserContext.IPAddress);

                if (UserContext.Location != null)
                    request.AddQueryString("ul", string.Format("{0},{1}", UserContext.Location.Item1, UserContext.Location.Item2));

                if (UserContext.MapView != null)
                    request.AddQueryString("umv", string.Format("{0},{1},{2},{3}", UserContext.MapView.Item1, UserContext.MapView.Item2, UserContext.MapView.Item3, UserContext.MapView.Item4));
            }
        }
    }
}
