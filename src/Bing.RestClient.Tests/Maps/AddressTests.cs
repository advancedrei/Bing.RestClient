using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bing.RestClient.Tests.Maps
{
    [TestClass]
    public class AddressTests
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
        //public async Task GetAddress()
        //{
        //    var address = await _client.GetAddress(44.9108238220215, -93.1702041625977);

        //    Assert.IsNotNull(address);
        //}

        //[TestMethod]
        //public async Task RoundtripPostalCode()
        //{
        //    var coord = await _client.GetCoordinate(new Address() { PostalCode = "55116", CountryRegion = "US" });
        //    var address = await _client.GetAddress(coord.Item1, coord.Item2);

        //    Assert.AreEqual(address.PostalCode, "55116");
        //}

        //[TestMethod]
        //public async Task ParseAnAddress()
        //{
        //    var address = await _client.ParseAddress("One Microsoft Way, Redmond, WA 98052");

        //    Assert.AreEqual(address.AddressLine, "1 Microsoft Way");
        //    Assert.AreEqual(address.Locality, "Redmond");
        //    Assert.AreEqual(address.AdminDistrict, "WA");
        //    Assert.AreEqual(address.PostalCode, "98052");
        //    Assert.AreEqual(address.CountryRegion, "United States");
        //}

        //[TestMethod]
        //public async Task ParseACanadianAddress()
        //{
        //    //var coord = new Tuple<double, double>(62.832908630371094, -95.913322448730469);
        //    //var service = new GeoCoder(APIKEY.Key, "Portable Bing GeoCoder unit tests", "en-CA", new UserContext(coord));

        //    var address = await _client.ParseAddress("1950 Meadowvale Blvd., Mississauga, ON L5N 8L9");

        //    Assert.AreEqual(address.AddressLine, "1950 Meadowvale Blvd");
        //    Assert.AreEqual(address.Locality, "Mississauga");
        //    Assert.AreEqual(address.AdminDistrict, "ON");
        //    Assert.AreEqual(address.PostalCode, "L5N 8L9");
        //    Assert.AreEqual(address.CountryRegion, "Canada");
        //}
    }
}
