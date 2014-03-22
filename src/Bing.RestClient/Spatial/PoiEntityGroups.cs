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
                //PoiEntityTypes.RestArea,
                //PoiEntityTypes.HighwayExit,
                PoiEntityTypes.PublicTransitAccess,
                PoiEntityTypes.PublicTransitStop,
            };
        }


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
                PoiEntityTypes.AgriculturalProductMarket,
                PoiEntityTypes.Bookstore,
                PoiEntityTypes.HistoricalMonument,
                PoiEntityTypes.Museum,
                PoiEntityTypes.Nightlife,
                PoiEntityTypes.PerformingArts,
                PoiEntityTypes.Theater,
                PoiEntityTypes.Winery,

            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> NightLife()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.Cinema,
                PoiEntityTypes.BowlingAlley,
                PoiEntityTypes.BowlingCentre,
                PoiEntityTypes.Casino,
                PoiEntityTypes.Theater,
                PoiEntityTypes.AgriculturalProductMarket,
                PoiEntityTypes.Bookstore,
                PoiEntityTypes.Museum,
                PoiEntityTypes.BarOrPub
            };
        }

        #endregion

        #region Education

        /// <summary>
        /// A list of all entities associated with Educations.
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> Education()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.HigherEducation,
                PoiEntityTypes.HistoricalMonument,
                PoiEntityTypes.Library,
                PoiEntityTypes.Museum,
                PoiEntityTypes.School,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> Schools()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.School,
                PoiEntityTypes.HigherEducation
            };
        }

        #endregion

        #region Healthcare

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> Healthcare()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.Dentist,
                PoiEntityTypes.Hospital,
                PoiEntityTypes.MedicalService,
                PoiEntityTypes.Optical,
                PoiEntityTypes.Pharmacy,
                PoiEntityTypes.Physician,
            };
        }

        #endregion

        #region Sports

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> Sports()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.SportingAndInstructionalCamp,
                PoiEntityTypes.Boating,
                PoiEntityTypes.RaceTrack,
                PoiEntityTypes.GolfPracticeRange,
                PoiEntityTypes.HealthClub,
                PoiEntityTypes.BowlingAlley,
                PoiEntityTypes.SportsActivities,
                PoiEntityTypes.BowlingCentre,
                PoiEntityTypes.SportsComplex,
                PoiEntityTypes.ParkOrRecreationArea,
                PoiEntityTypes.GolfCourse,
                PoiEntityTypes.AmusementPark,
                PoiEntityTypes.SportsCentre,
                PoiEntityTypes.IceSkatingRink,
                PoiEntityTypes.SkiResort,
                PoiEntityTypes.PublicSportsAirport,

            };
        }

        #endregion

        #region Shopping

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> Clothing()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.ClothingStore,
                PoiEntityTypes.MensApparel,
                PoiEntityTypes.ShoeStore,
                PoiEntityTypes.SpecialtyClothingStore,
                PoiEntityTypes.WomensApparel,
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<PoiEntityTypes> Grocery()
        {
            return new List<PoiEntityTypes>()
            {
                PoiEntityTypes.ConvenienceStore,
                PoiEntityTypes.GroceryStore,
                PoiEntityTypes.SpecialtyFoodStore,
            };
        }


        #endregion

    }
}
