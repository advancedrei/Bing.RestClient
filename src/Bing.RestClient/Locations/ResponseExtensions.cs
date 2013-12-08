using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

using Bing.Maps;

namespace Bing.Locations
{
    /// <summary>
    /// Helper methods for spelunking the GeoResultSet and its child collections
    /// </summary>
    public static class GeoResultExtensions
    {
        public static IEnumerable<Address> GetAddresses(this Response result)
        {
            return from rs in result.resourceSets
                   from r in rs.resources
                   select r.address;
        }

        public static IEnumerable<Tuple<double, double>> GetCoordinates(this Response result)
        {
            return from rs in result.resourceSets
                   from r in rs.resources
                   let pts = r.point.Coordinates
                   select new Tuple<double, double>(pts[0], pts[1]);
        }

        public static Address GetFirstAddress(this Response result)
        {
            return result.GetAddresses().FirstOrDefault();
        }

        public static Tuple<double, double> GetFirstCoordinate(this Response result)
        {
            return result.GetCoordinates().FirstOrDefault() ?? new Tuple<double, double>(0, 0);
        }

        public static string GetFirstAddressProperty(this Response result, Func<Address, string> selector)
        {
            Debug.Assert(selector != null);

            var address = result.GetFirstAddress();
            if (address != null)
                return selector(address);

            return "";
        }

        public static string GetFirstFormattedAddress(this Response result)
        {
            return result.GetFirstAddressProperty(a => a.FormattedAddress);
        }

        public static string GetFirstAddressPart(this Response result, string part)
        {
            return result.GetFirstAddressProperty(GetAddressPartSelector(part));
        }

        private static Func<Address, string> GetAddressPartSelector(string part)
        {
            if (part.Equals("address", StringComparison.OrdinalIgnoreCase))
                return a => a.AddressLine;

            if (part.Equals("Neighborhood", StringComparison.OrdinalIgnoreCase))
                return a => a.Neighborhood;

            if (part.Equals("postcode1", StringComparison.OrdinalIgnoreCase))
                return a => a.PostalCode;

            if (part.Equals("PopulatedPlace", StringComparison.OrdinalIgnoreCase))
                return a => a.Locality;

            if (part.Equals("AdminDivision1", StringComparison.OrdinalIgnoreCase))
                return a => a.AdminDistrict;

            if (part.Equals("AdminDivision2", StringComparison.OrdinalIgnoreCase))
                return a => a.AdminDistrict2;

            if (part.Equals("CountryRegion", StringComparison.OrdinalIgnoreCase))
                return a => a.CountryRegion;

            Debug.Assert(false);
            return a => "";
        }
    }
}
