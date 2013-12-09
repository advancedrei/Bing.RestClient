using System.Runtime.Serialization;

namespace Bing.Core
{
    /// <summary>
    /// A bounding box is defined by two latitudes and two longitudes that represent the four sides of a rectangular area on the Earth. 
    /// </summary>
    [DataContract]
    public class BoundingBox
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "southLatitude", EmitDefaultValue = false)]
        public double SouthLatitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "westLongitude", EmitDefaultValue = false)]
        public double WestLongitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "northLatitude", EmitDefaultValue = false)]
        public double NorthLatitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "eastLongitude", EmitDefaultValue = false)]
        public double EastLongitude { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor.
        /// </summary>
        public BoundingBox()
        {
            
        }

        /// <summary>
        /// Constructs a BoundingBox with the coordinates in the order they are specified in Bing queries (SWNE).
        /// </summary>
        /// <param name="southLatitude">The southern-most edge of the box.</param>
        /// <param name="westLongitude">The western-most edge of the box.</param>
        /// <param name="northLatitude">The northern-most edge of the box.</param>
        /// <param name="eastLongitude">The eastern-most edge of the box.</param>
        public BoundingBox(double southLatitude, double westLongitude, double northLatitude, double eastLongitude)
        {
            SouthLatitude = southLatitude;
            WestLongitude = westLongitude;
            NorthLatitude = northLatitude;
            EastLongitude = eastLongitude;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Outputs a BoundingBox with the coordinates in the order they are specified in Bing queries (SWNE).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", SouthLatitude, WestLongitude, NorthLatitude, EastLongitude);
        }

        #endregion

    }
}