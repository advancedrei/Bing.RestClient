using System.Runtime.Serialization;

namespace Bing.Spatial
{
    [DataContract(Name = "d", Namespace = "")]
    internal class SpatialResponseWrapper<T> where T : class
    {

        [DataMember(Name = "d")]
        public T Response { get; set; }

    }
}