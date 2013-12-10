using System.Reflection;
using Bing.Spatial;
using PortableRest;

namespace Bing
{

    /// <summary>
    /// The base for all Bing REST Clients in this library. Handles setting the UserAgent.
    /// </summary>
    public abstract class BingClientBase : RestClient
    {

        #region Private Members

        /// <summary>
        /// 
        /// </summary>
        internal string ApiKey { get; set; }

        #endregion

        /// <summary>
        /// Sets the API Key and the UserAgent for the implemented Bing Clients.
        /// </summary>
        /// <param name="apiKey">The key registered to a given user to access the Bing APIs.</param>
        protected BingClientBase(string apiKey)
        {
            ApiKey = apiKey;

            // PCL-friendly way to get current version
            var thisAssembly = typeof(PointOfInterest).GetTypeInfo().Assembly;
            var thisAssemblyName = new AssemblyName(thisAssembly.FullName);
            var thisVersion = thisAssemblyName.Version;

            var prAssembly = typeof(RestRequest).GetTypeInfo().Assembly;
            var prAssemblyName = new AssemblyName(prAssembly.FullName);
            var prVersion = prAssemblyName.Version;

            UserAgent = string.Format("Bing Client for .NET {0} (PortableRest {1})", thisVersion, prVersion);
        }

    }
}
