using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bing.Spatial;
using PortableRest;

namespace Bing
{

    /// <summary>
    /// 
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
        /// <param name="apiKey"></param>
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
