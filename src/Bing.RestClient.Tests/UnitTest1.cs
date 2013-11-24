using System.Collections.Generic;
using System.Threading.Tasks;
using Bing.Spatial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bing.RestClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static string _apiKey;
        private static SpatialDataClient _client;

        public TestContext TestContext { get; set; }


        [ClassInitialize]
        public static void NewRelicClientTests(TestContext context)
        {
            _apiKey = "AvJQsrmfwSe4_eSLugsqhHL9F7NdEAyEm8J7Vi4FSYbcdVGAk0T9kM3UtyElbcLf";
            _client = new SpatialDataClient(_apiKey);

        }

        [TestMethod]
        public async Task GetSingleNAPOITest()
        {
            var account = await _client.GetById<PointOfInterest>("NorthAmericaPOI", "996564435");
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public async Task GetMultipleNAPOITest()
        {
            var ids = new List<string>
            {
                "996564435",
                "17254391"
            };
            var account = await _client.GetByIds<PointOfInterest>("NorthAmericaPOI", ids);
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public async Task GetMultipleNAPOITest2()
        {
            var ids = new List<string>
            {
                "996564435",
                "17254391"
            };
            var account = await _client.GetByIds<PointOfInterest>("NorthAmericaPOI", ids, skip: 1, top: 10);
            Assert.IsNotNull(account);
        }

        [TestMethod]
        public async Task GetMultipleNAPOITest3()
        {
            var ids = new List<string>
            {
                "996564435",
                "17254391"
            };
            var account = await _client.Find<PointOfInterest>("NorthAmericaPOI", "1313 S Harbor Blvd, Anaheim CA, 92802", 
                _client.ConvertMiToKm(5));
            Assert.IsNotNull(account);
        }
    }
}
