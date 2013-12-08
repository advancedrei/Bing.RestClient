using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Bing.Locations;

namespace GeoCoderTests
{
    [TestClass]
    public class AddressTests
    {
        private BingLocationsRestClient _service;

        [TestInitialize]
        public void Init()
        {
            _service = new BingLocationsRestClient(APIKEY.Key, "Portable Bing GeoCoder unit tests");
        }

        [TestMethod]
        public async Task GetAddress()
        {
            var address = await _service.GetAddress(44.9108238220215, -93.1702041625977);

            Assert.IsNotNull(address);
        }

        [TestMethod]
        public async Task RoundtripPostalCode()
        {
            var coord = await _service.GetCoordinate(new Address() { postalCode = "55116", countryRegion = "US" });
            var address = await _service.GetAddress(coord.Item1, coord.Item2);

            Assert.AreEqual(address.postalCode, "55116");
        }

        [TestMethod]
        public async Task ParseAnAddress()
        {
            var address = await _service.ParseAddress("One Microsoft Way, Redmond, WA 98052");

            Assert.AreEqual(address.addressLine, "1 Microsoft Way");
            Assert.AreEqual(address.locality, "Redmond");
            Assert.AreEqual(address.adminDistrict, "WA");
            Assert.AreEqual(address.postalCode, "98052");
            Assert.AreEqual(address.countryRegion, "United States");
        }

        [TestMethod]
        public async Task ParseACanadianAddress()
        {
            //var coord = new Tuple<double, double>(62.832908630371094, -95.913322448730469);
            //var service = new GeoCoder(APIKEY.Key, "Portable Bing GeoCoder unit tests", "en-CA", new UserContext(coord));

            var address = await _service.ParseAddress("1950 Meadowvale Blvd., Mississauga, ON L5N 8L9");

            Assert.AreEqual(address.addressLine, "1950 Meadowvale Blvd");
            Assert.AreEqual(address.locality, "Mississauga");
            Assert.AreEqual(address.adminDistrict, "ON");
            Assert.AreEqual(address.postalCode, "L5N 8L9");
            Assert.AreEqual(address.countryRegion, "Canada");
        }
    }
}
