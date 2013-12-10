using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bing.Maps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bing.RestClient.Tests.Maps
{
    [TestClass]
    public class CoordinateTests
    {

        private static string _apiKey;
        private static MapsClient _client;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _apiKey = "AvJQsrmfwSe4_eSLugsqhHL9F7NdEAyEm8J7Vi4FSYbcdVGAk0T9kM3UtyElbcLf";
            _client = new MapsClient(_apiKey);

        }

        //[TestMethod]
        //public async Task CoordinateFromPostalCode()
        //{
        //    var coord = await _client.GetCoordinate(null, null, null, "55116", "US");

        //    Assert.IsTrue(coord.Item1.AboutEqual(44.9108238220215));
        //    Assert.IsTrue(coord.Item2.AboutEqual(-93.1702041625977));
        //}

        //[TestMethod]
        //public async Task PostalCodeFromCoordinate()
        //{
        //    var postalCode = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, "Postcode1");

        //    Assert.AreEqual(postalCode, "55116");
        //}

        //[TestMethod]
        //public async Task CoordinateFromAddress()
        //{
        //    var coord = await _client.GetCoordinate("One Microsoft Way", "Redmond", "WA", "98052", "US");

        //    Assert.IsTrue(coord.Item1.AboutEqual(47.640049383044243));
        //    Assert.IsTrue(coord.Item2.AboutEqual(-122.12979689240456));
        //}

        [TestMethod]
        public async Task CoordinateFromAddressObject()
        {
            var address = new Address()
            {
                AddressLine = "One Microsoft Way",
                Locality = "Redmond",
                AdminDistrict = "WA",
                PostalCode = "98052",
                CountryRegion = "US"
            };
            var coord = await _client.LocationQuery(address);
            var result = coord.GetCoordinates().FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Coordinates[0].AboutEqual(47.640049383044243));
            Assert.IsTrue(result.Coordinates[1].AboutEqual(-122.12979689240456));
        }

        [TestMethod]
        public async Task CoordinateFromAddressQuery()
        {
            var coord = await _client.LocationQuery("One Microsoft Way, Redmond, WA 98052");
            var result = coord.GetCoordinates().FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Coordinates[0].AboutEqual(47.640049383044243));
            Assert.IsTrue(result.Coordinates[1].AboutEqual(-122.12979689240456));
        }

        [TestMethod]
        public async Task CoordinateFromLandmark()
        {
            var coord = await _client.LocationQuery("Eiffel Tower");
            var result = coord.GetCoordinates().FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Coordinates[0].AboutEqual(48.858600616455078));
            Assert.IsTrue(result.Coordinates[1].AboutEqual(2.2939798831939697));
        }

        [TestMethod]
        public void CheckPointCompression()
        {
            var points = new List<Point>
            {
                new Point(35.894309002906084, -110.72522000409663),
                new Point(35.893930979073048, -110.72577999904752),
                new Point(35.893744984641671, -110.72606003843248),
                new Point(35.893366960808635, -110.72661500424147)
            };
            Assert.AreEqual("vx1vilihnM6hR7mEl2Q", _client.CompressPoints(points));
        }
    }
}