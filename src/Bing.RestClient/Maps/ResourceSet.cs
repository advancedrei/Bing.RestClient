using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bing.Maps
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ResourceSet<T> where T : Resource

{
    /// <summary>
    /// An estimate of the total number of resources in the ResourceSet.
    /// </summary>
    [DataMember(Name = "estimatedTotal", EmitDefaultValue = false)]
    public long EstimatedTotal { get; set; }

    /// <summary>
    /// A collection of one or more resources. The resources that are returned depend on the request. 
    /// Information about resources is provided in the API reference for each Bing Maps REST Services API. 
    /// </summary>
    [DataMember(Name = "resources", EmitDefaultValue = false)]
    public List<T> Resources { get; set; }
}
}