using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bing.Spatial
{

    /// <summary>
    /// Common groups of related Points of Interest.
    /// </summary>
    /// <remarks>These were determined by AdvancedREI, not Bing.</remarks>
    public static class PoiEntityGroups
    {

        #region Transportation

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
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
