using System.Collections.Generic;

using Bing.Maps;
using Bing.Core;

namespace Bing.Locations
{
    public class GeocodePoint
    {
        public string type { get; set; }
        public List<string> usageTypes { get; set; }
        public List<double> coordinates { get; set; }
        public string calculationMethod { get; set; }
    }

    public class Resource
    {
        public Address address { get; set; }
        public string __type { get; set; }
        public string entityType { get; set; }
        public string confidence { get; set; }
        public Point point { get; set; }
        public List<string> matchCodes { get; set; }
        public string name { get; set; }
        public List<GeocodePoint> geocodePoints { get; set; }
        public List<double> bbox { get; set; }
    }

    public class ResourceSet
    {
        public List<Resource> resources { get; set; }
        public int estimatedTotal { get; set; }
    }

    public class Response
    {
        public string copyright { get; set; }
        public string brandLogoUri { get; set; }
        public string traceId { get; set; }
        public string statusDescription { get; set; }
        public int statusCode { get; set; }
        public List<ResourceSet> resourceSets { get; set; }
        public string authenticationResultCode { get; set; }
    }
}
