using System;
using Bing.Core;
using Bing.Maps;

namespace Bing.Maps
{
    /// <summary>
    /// Used to provide more accurate results based on the user's locations
    /// Typically only one of the properties will be set
    /// </summary>
    public class UserContext
    {

        #region Properties

        /// <summary>
        /// The default address is the IPv4 address of the request.
        /// </summary>
        /// <remarks>
        /// When you specify this parameter, the location associated with the IP address is 
        /// taken into account in computing the results of a location query.
        /// </remarks>
        public string IpAddress { get; private set; }

        /// <summary>
        /// A point on the earth specified as a latitude and longitude. 
        /// </summary>
        /// <remarks>
        /// When you specify this parameter, the user’s location is taken into account and 
        /// the results returned may be more relevant to the user.
        /// </remarks>
        public Point Location { get; private set; }

        /// <summary>
        /// A point on the earth specified as a latitude and longitude. 
        /// </summary>
        /// <remarks>
        /// When you specify this parameter, the geographical area is taken into account when 
        /// computing the results of a location query.
        /// </remarks>
        public BoundingBox MapView { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ip">The IPv4 address to search near.</param>
        public UserContext(string ip)
        {
            IpAddress = ip;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public UserContext(double latitude, double longitude)
        {
            Location = new Point(latitude, longitude);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapView">A rectangular area on the earth defined as a bounding box object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserContext(BoundingBox mapView)
        {
            if (mapView == null) throw new ArgumentNullException("mapView");
            MapView = mapView;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ip">The user's ip address</param>
        /// <param name="location">The user's location</param>
        /// <param name="mapView">A rectangular area on the earth defined as a bounding box object.</param>
        public UserContext(string ip, Point location, BoundingBox mapView)
        {
            IpAddress = ip;
            Location = location;
            MapView = mapView;
        }

        #endregion

    }
}
