using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bing.Core;
using Bing.Spatial;
using PortableRest;

namespace Bing
{
    
    /// <summary>
    /// 
    /// </summary>
    public class SpatialDataClient : BingClientBase
    {

        #region Public Properties

        /// <summary>
        /// The DataSources that are available to the Spatial Data API
        /// </summary>
        /// <remarks>If you've added your own data sources through the Management APIs, you can add them with the AddDataSource method.</remarks>
        public Dictionary<string, string> DataSources { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the SpatialDataClient.
        /// </summary>
        /// <param name="apiKey">The key registered to a given user to access the Bing APIs.</param>
        public SpatialDataClient(string apiKey) : base(apiKey)
        {

            BaseUrl = "https://spatial.virtualearth.net/REST/v1/data";
            DataSources = new Dictionary<string, string>()
            {
                {"NorthAmericaPOI", "f22876ec257b474b82fe2ffcb8393150/NavteqNA/NavteqPOIs"},
                {"EuropePOI", "c2ae584bbccc4916a0acf75d1e6947b4/NavteqEU/NavteqPOIs"},
                {"TrafficIncidents", "8F77935E46704C718E45F52D0D5550A6/TrafficIncidents/TrafficIncident"},
            };
        }

        #endregion

        #region Public Methods

        #region AddDataSource

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="url">The Url segment for the datasource. DO NOT use leading or trailing slashes.</param>
        /// <remarks></remarks>
        public void AddDataSource(string name, string url)
        {
            if (!DataSources.ContainsKey(name))
            {
                DataSources.Add(name, url);
            }
        }

        /// <summary>
        /// Add a data source to the list of available datasources.
        /// </summary>
        /// <remarks>Use this overload if you don't want to worry about building the URL fragment yourself.</remarks>
        /// <param name="name"></param>
        /// <param name="accessId"></param>
        /// <param name="dataSourceName"></param>
        /// <param name="entityTypeName"></param>
        public void AddDataSource(string name, string accessId, string dataSourceName, string entityTypeName)
        {
            if (!DataSources.ContainsKey(name))
            {
                DataSources.Add(name, string.Format("{0}/{1}/{2}", accessId, dataSourceName, entityTypeName));
            }
        }

        #endregion

        #region GetById(s)

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="dataSourceName"></param>
        /// <param name="id"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public async Task<TReturn> GetById<TReturn>(string dataSourceName, string id,
            string filter = "", string orderBy = "", int skip = 0, int top = 25) where TReturn : class
        {
            if (string.IsNullOrWhiteSpace(dataSourceName))
            {
                throw new ArgumentException("The dataSourceName cannot be blank.", "dataSourceName");
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("You must specify an EntityID", "id");
            }

            var request = new RestRequest(DataSources[dataSourceName] + "('{entityId}')") { ContentType = ContentTypes.Json };
            request.AddUrlSegment("entityId", id);
            PrepRequest(ref request, filter, orderBy, skip, top);

            var result = await ExecuteAsync<SpatialResponseWrapper<TReturn>>(request);
            return result.Response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="dataSourceName"></param>
        /// <param name="ids"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public async Task<List<TReturn>> GetByIds<TReturn>(string dataSourceName, List<string> ids,
            string filter = "", string orderBy = "", int skip = 0, int top = 25) where TReturn : class
        {
            if (string.IsNullOrWhiteSpace(dataSourceName))
            {
                throw new ArgumentException("The dataSourceName cannot be blank.", "dataSourceName");
            }
            if (ids.Count() > 50)
            {
                throw new ArgumentException("The Bing Spatial Data API does not support querying more than 50 IDs.", "ids");
            }
            
            var request = new RestRequest(DataSources[dataSourceName]) { ContentType = ContentTypes.Json };

            var values = ids.Aggregate(new StringBuilder(), (current, next) =>
                current.Append(string.Format("'{0}',", next))).ToString();

            var formatString = string.IsNullOrWhiteSpace(filter) ? "entityId in ({0})" : "entityId in ({0}) And {1}";
            var newFilter = string.Format(formatString, values.TrimEnd(Convert.ToChar(",")), filter);

            PrepRequest(ref request, newFilter, orderBy, skip, top);
            var result = await ExecuteAsync<SpatialResponseListWrapper<TReturn>>(request);
            return result.Response.Results;
        }

        #endregion

        #region Find

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="dataSourceName"></param>
        /// <param name="searchRadius"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public async Task<List<TReturn>> Find<TReturn>(string dataSourceName, SearchRadius searchRadius,
            string filter = "", string orderBy = "", int skip = 0, int top = 25) where TReturn : class
        {
            if (string.IsNullOrWhiteSpace(dataSourceName))
            {
                throw new ArgumentException("The dataSourceName cannot be blank.", "dataSourceName");
            }
            if (searchRadius == null)
            {
                throw new ArgumentException("searchRadius cannot be null.", "searchRadius");
            }

            var request = new RestRequest(DataSources[dataSourceName]) { ContentType = ContentTypes.Json };

            request.AddQueryString("spatialFilter", string.Format("nearby({0})", searchRadius));
            PrepRequest(ref request, filter, orderBy, skip, top);
            var result = await ExecuteAsync<SpatialResponseListWrapper<TReturn>>(request);
            return result.Response.Results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="dataSourceName"></param>
        /// <param name="boundingBox"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public async Task<List<TReturn>> Find<TReturn>(string dataSourceName, BoundingBox boundingBox, 
            string filter = "", string orderBy = "", int skip = 0, int top = 25) where TReturn : class

        {
            if (string.IsNullOrWhiteSpace(dataSourceName))
            {
                throw new ArgumentException("The dataSourceName cannot be blank.", "dataSourceName");
            }
            if (boundingBox == null)
            {
                throw new ArgumentException("boundingBox cannot be null.", "boundingBox");
            }

            var request = new RestRequest(DataSources[dataSourceName]) { ContentType = ContentTypes.Json };

            request.AddQueryString("spatialFilter", string.Format("bbox({0})", boundingBox));
            PrepRequest(ref request, filter, orderBy, skip, top);
            var result = await ExecuteAsync<SpatialResponseListWrapper<TReturn>>(request);
            return result.Response.Results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="dataSourceName"></param>
        /// <param name="address"></param>
        /// <param name="distance"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public async Task<List<TReturn>> Find<TReturn>(string dataSourceName, string address, double distance,
            string filter = "", string orderBy = "", int skip = 0, int top = 25) where TReturn : class
        {
            if (string.IsNullOrWhiteSpace(dataSourceName))
            {
                throw new ArgumentException("The dataSourceName cannot be blank.", "dataSourceName");
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("The address cannot be blank.", "address");
            }

            var request = new RestRequest(DataSources[dataSourceName]) { ContentType = ContentTypes.Json };

            request.AddQueryString("spatialFilter", string.Format("nearby('{0}',{1})", address, distance));
            PrepRequest(ref request, filter, orderBy, skip, top);
            var result = await ExecuteAsync<SpatialResponseListWrapper<TReturn>>(request);
            return result.Response.Results;
        }

        #endregion

        #region ConvertMiToKm

        /// <summary>
        /// Helper method to convert miles to kilometers.
        /// </summary>
        /// <param name="miles"></param>
        /// <returns></returns>
        public double ConvertMiToKm(double miles)
        {
            return miles*1.609344;
        }

        #endregion

        #endregion

        #region Internal Methods

        /// <summary>
        /// Prepares the 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="skip"></param>
        /// <param name="top"></param>
        private void PrepRequest(ref RestRequest request, string filter, string orderBy, int skip, int top)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                request.AddQueryString("$filter", filter);
            }
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                request.AddQueryString("$orderBy", filter);
            }
            if (skip != 0)
            {
                request.AddQueryString("$skip", skip);
            }
            if (top != 25)
            {
                request.AddQueryString("$top", top);
            }
            request.AddQueryString("$format", "json");
            request.AddQueryString("key", ApiKey);
        }

        #endregion

    }
}
