using System.Runtime.Serialization;

namespace Bing.Spatial
{
    [DataContract(Name = "d", Namespace = "")]
    internal class SpatialResponseListWrapper<T> where T : class
    {

        [DataMember(Name = "d")]
        public SpatialResponseList<T> Response { get; set; }




    }
}