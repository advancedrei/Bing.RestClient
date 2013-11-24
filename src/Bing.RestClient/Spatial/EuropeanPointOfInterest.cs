using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bing.Spatial
{

    [DataContract(Name = "d", Namespace = "")]
    public class EuropeanPointOfInterest : PointOfInterest
    {

        [DataMember]
        public string LanguageCode { get; set; }

    }
}
