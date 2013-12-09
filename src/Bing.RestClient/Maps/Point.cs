using System.Runtime.Serialization;

namespace Bing.Maps
{

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Point : Shape
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// The latitude and longitude coordinates of the geocode point.
        /// </summary>
        [DataMember(Name = "coordinates", EmitDefaultValue = false)]
        public double[] Coordinates { get; set; }

        /// <summary>
        /// The method that was used to compute the geocode point. 
        /// </summary>
        [DataMember(Name = "calculationMethod", EmitDefaultValue = false)]
        public string CalculationMethod { get; set; }

        /// <summary>
        /// The best use for the geocode point.
        /// </summary>
        [DataMember(Name = "usageTypes", EmitDefaultValue = false)]
        public string[] UsageTypes { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public Point()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Point(double latitude, double longitude)
        {
            Coordinates = new[] {latitude, longitude};
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1}", Coordinates[0], Coordinates[1]);
        }
    }
}