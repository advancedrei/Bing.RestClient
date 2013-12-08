using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Bing.Locations;

namespace GeoCoderTests
{
    [TestClass]
    public class AddressPartTests
    {
        private BingLocationsRestClient _service;

        [TestInitialize]
        public void Init()
        {
            _service = new BingLocationsRestClient(APIKEY.Key, "Portable Bing GeoCoder unit tests");
        }

        [TestMethod]
        public async Task GetFormattedAddressFromCoordinate()
        {
            var address = await _service.GetFormattedAddress(44.9108238220215, -93.1702041625977);

            Assert.AreEqual(address, "1012 Davern St, St Paul, MN 55116");
        }

        [TestMethod]
        public async Task GetNeighborhoodFromCoordinate()
        {
            var address = await _service.GetAddressPart(44.9108238220215, -93.1702041625977, "Neighborhood");

            Assert.AreEqual(address, "Highland");
        }

        [TestMethod]
        public async Task GetAddressFromCoordinate()
        {
            var address = await _service.GetAddressPart(44.9108238220215, -93.1702041625977, "Address");

            Assert.AreEqual(address, "1012 Davern St");
        }

        [TestMethod]
        public async Task GetPostalCodeFromCoordinate()
        {
            var postalCode = await _service.GetAddressPart(44.9108238220215, -93.1702041625977, "Postcode1");

            Assert.AreEqual(postalCode, "55116");
        }

        [TestMethod]
        public async Task GetCityFromCoordinate()
        {
            var city = await _service.GetAddressPart(44.9108238220215, -93.1702041625977, "PopulatedPlace");

            Assert.AreEqual(city, "St Paul");
        }

        [TestMethod]
        public async Task GetCountyFromCoordinate()
        {
            var county = await _service.GetAddressPart(44.9108238220215, -93.1702041625977, "AdminDivision2");

            Assert.AreEqual(county, "Ramsey Co.");
        }

        [TestMethod]
        public async Task GetStateFromCoordinate()
        {
            var state = await _service.GetAddressPart(44.9108238220215, -93.1702041625977, "AdminDivision1");

            Assert.AreEqual(state, "MN");
        }

        [TestMethod]
        public async Task GetCountryFromCoordinate()
        {
            var country = await _service.GetAddressPart(44.9108238220215, -93.1702041625977, "CountryRegion");

            Assert.AreEqual(country, "United States");
        }

        [TestMethod]
        public async Task GetCountryFromCoordinateUsingEnum()
        {
            var country = await _service.GetAddressPart(44.9108238220215, -93.1702041625977, AddressEntityType.CountryRegion);

            Assert.AreEqual(country, "United States");
        }
    }
}
