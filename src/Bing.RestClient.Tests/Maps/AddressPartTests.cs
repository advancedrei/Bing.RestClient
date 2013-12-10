using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bing.RestClient.Tests.Maps
{
    [TestClass]
    public class AddressPartTests
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
        //public async Task GetFormattedAddressFromCoordinate()
        //{
        //    var address = await _client.GetFormattedAddress(44.9108238220215, -93.1702041625977);

        //    Assert.AreEqual(address, "1012 Davern St, St Paul, MN 55116");
        //}

        //[TestMethod]
        //public async Task GetNeighborhoodFromCoordinate()
        //{
        //    var address = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, "Neighborhood");

        //    Assert.AreEqual(address, "Highland");
        //}

        //[TestMethod]
        //public async Task GetAddressFromCoordinate()
        //{
        //    var address = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, "Address");

        //    Assert.AreEqual(address, "1012 Davern St");
        //}

        //[TestMethod]
        //public async Task GetPostalCodeFromCoordinate()
        //{
        //    var postalCode = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, "Postcode1");

        //    Assert.AreEqual(postalCode, "55116");
        //}

        //[TestMethod]
        //public async Task GetCityFromCoordinate()
        //{
        //    var city = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, "PopulatedPlace");

        //    Assert.AreEqual(city, "St Paul");
        //}

        //[TestMethod]
        //public async Task GetCountyFromCoordinate()
        //{
        //    var county = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, "AdminDivision2");

        //    Assert.AreEqual(county, "Ramsey Co.");
        //}

        //[TestMethod]
        //public async Task GetStateFromCoordinate()
        //{
        //    var state = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, "AdminDivision1");

        //    Assert.AreEqual(state, "MN");
        //}

        //[TestMethod]
        //public async Task GetCountryFromCoordinate()
        //{
        //    var country = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, "CountryRegion");

        //    Assert.AreEqual(country, "United States");
        //}

        //[TestMethod]
        //public async Task GetCountryFromCoordinateUsingEnum()
        //{
        //    var country = await _client.GetAddressPart(44.9108238220215, -93.1702041625977, AddressEntityType.CountryRegion);

        //    Assert.AreEqual(country, "United States");
        //}
    }
}
