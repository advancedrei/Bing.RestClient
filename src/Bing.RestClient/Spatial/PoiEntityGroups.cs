using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bing.Spatial
{

    /// <summary>
    /// Common groups of related Points of Interest.
    /// </summary>
    /// <remarks>These were determined by AdvancedREI, not Bing.</remarks>
    public static class PoiEntityGroups
    {

        #region BuildFilter

        /// <summary>
        /// Converts a list of PoiEntityTypes to the format the Bing API requires.
        /// </summary>
        /// <param name="pointsOfInterest">The list of Points of Interest to search for.</param>
        /// <returns>An Odata-formatted filter clause that can be passed to the Find() method.</returns>
        public static string BuildFilter(List<PoiEntityTypes> pointsOfInterest)
        {
            var values = pointsOfInterest.Aggregate(new StringBuilder(), (current, next) =>
                current.Append(string.Format("{0},", (int)next))).ToString();

            return string.Format("entityTypeId in ({0})", values.TrimEnd(Convert.ToChar(",")));
        }

        #endregion

        #region Transportation

        /// <summary>
        /// Gets a list of all possible transportation-related entities.
        /// </summary>
        /// <returns>A List of PoiEntityTypes that represent transportation-related entities.</returns>
        public static List<PoiEntityTypes> Transportation()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.TrainStation,
                PoiEntityTypes.CommuterRailStation,
                PoiEntityTypes.BusStation,
                PoiEntityTypes.FerryTerminal,
                PoiEntityTypes.Marina,
                PoiEntityTypes.Airport,
                PoiEntityTypes.PetrolOrGasStation,
                PoiEntityTypes.RentalCarAgency,
                PoiEntityTypes.ParkingLot,
                PoiEntityTypes.ParkAndRide,
                PoiEntityTypes.ParkingGarage,
                PoiEntityTypes.RestArea,
                PoiEntityTypes.LocalTransit,
                PoiEntityTypes.TruckStopOrPlaza,
                PoiEntityTypes.RoadAssistance,
                PoiEntityTypes.HighwayExit,
                PoiEntityTypes.TransportationService,
                PoiEntityTypes.PublicTransitAccess,
                PoiEntityTypes.PublicTransitStop,
                PoiEntityTypes.WeighStation,
                PoiEntityTypes.CargoCentre,
                PoiEntityTypes.TruckParking,
                PoiEntityTypes.TaxiStand,
                PoiEntityTypes.RVPark
            };
        }

        /// <summary>
        /// Gets a list of all vehicle parking facilities.
        /// </summary>
        /// <returns>A List of PoiEntityTypes that represent vehicle parking facilities.</returns>
        public static List<PoiEntityTypes> Parking()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.ParkingLot,
                PoiEntityTypes.ParkAndRide,
                PoiEntityTypes.ParkingGarage,
                PoiEntityTypes.RestArea,
                PoiEntityTypes.TruckStopOrPlaza,
                PoiEntityTypes.TruckParking,
                PoiEntityTypes.RVPark
            };
        }

        /// <summary>
        /// Gets a list of all public transportation entities.
        /// </summary>
        /// <returns>A List of PoiEntityTypes that represent public transportation entities.</returns>
        public static List<PoiEntityTypes> PublicTransportation()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.TrainStation,
                PoiEntityTypes.CommuterRailStation,
                PoiEntityTypes.BusStation,
                PoiEntityTypes.FerryTerminal,
                PoiEntityTypes.Airport,
                PoiEntityTypes.ParkAndRide,
                PoiEntityTypes.RestArea,
                PoiEntityTypes.HighwayExit,
                PoiEntityTypes.PublicTransitAccess,
                PoiEntityTypes.PublicTransitStop,
            };
        }

        #endregion

        #region Financial Services

        /// <summary>
        /// Gets a list of all financial services entities.
        /// </summary>
        /// <returns>A List of PoiEntityTypes that represent financial services entities.</returns>
        public static List<PoiEntityTypes> Financial()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.ATM,
                PoiEntityTypes.Bank,
                PoiEntityTypes.TaxService,
                PoiEntityTypes.CheckCashingService,
                PoiEntityTypes.MoneyTransferringService,
                PoiEntityTypes.CurrencyExchange,
            };
        }

        /// <summary>
        /// Gets a list of all institutional financial services entities.
        /// </summary>
        /// <returns>A List of PoiEntityTypes that represent institutional financial services entities.</returns>
        // ReSharper disable once InconsistentNaming
        public static List<PoiEntityTypes> BanksAndATMs()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.ATM,
                PoiEntityTypes.Bank,
            };
        }

        /// <summary>
        /// Gets a list of all other non-banking financial services.
        /// </summary>
        /// <returns>A List of PoiEntityTypes that represent all other non-banking financial services.</returns>
        public static List<PoiEntityTypes> OtherFinancialServices()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.CheckCashingService,
                PoiEntityTypes.MoneyTransferringService,
                PoiEntityTypes.CurrencyExchange,
            };
        }

        #endregion

        #region Government

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> Government()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.TouristInformation,
                PoiEntityTypes.ConventionOrExhibitionCentre,
                PoiEntityTypes.CivicOrCommunityCentre,
                PoiEntityTypes.CityHall,
                PoiEntityTypes.CourtHouse,
                PoiEntityTypes.PoliceService,
                PoiEntityTypes.PoliceStation,
                PoiEntityTypes.SocialService,
                PoiEntityTypes.GovernmentOffice,
                PoiEntityTypes.FireDepartment,
                PoiEntityTypes.PostOffice,
                PoiEntityTypes.PublicRestroom,
                PoiEntityTypes.MilitaryBase,
                PoiEntityTypes.Embassy,
                PoiEntityTypes.CountyCouncil,
                PoiEntityTypes.BorderCrossing
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> GovernmentServices()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.PoliceService,
                PoiEntityTypes.PoliceStation,
                PoiEntityTypes.SocialService,
                PoiEntityTypes.FireDepartment,
                PoiEntityTypes.PostOffice,
            };
        }

        #endregion

        #region Entertainment and Culture

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> Culture()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.Winery,
                PoiEntityTypes.Nightlife,
                PoiEntityTypes.PerformingArts,
                PoiEntityTypes.Theater,
                PoiEntityTypes.AgriculturalProductMarket,
                PoiEntityTypes.Bookstore
            };
        }

        #endregion


    }
}
