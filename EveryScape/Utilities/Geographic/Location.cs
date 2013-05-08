using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryScape.Utilities.Geographic
{
	public class Location
	{
		private Angle _latitude;
		private Angle _longitude;
		private Distance _altitude;

		/// <summary>
		/// Returns a location object, with latitude and longitude set to defaults of 0,0 DecimalDegrees.
		/// </summary>
		public Location()
		{
			setLocation(new Angle(), new Angle(), new Distance());
		}


		/// <summary>
		/// Sets the location parameters, defaulting the altitude to 0 km.
		/// </summary>
		/// <param name="latitude"></param>
		/// <param name="longitude"></param>
		public void setLocation(Angle latitude, Angle longitude)
		{
			setLocation(latitude, longitude, new Distance());
		}

		/// <summary>
		/// Sets the location parameters.
		/// </summary>
		/// <param name="latitude">The angle of latitude.</param>
		/// <param name="longitude">The angle of longitude.</param>
		/// <param name="altitude">The distance of altitude.</param>
		public void setLocation(Angle latitude, Angle longitude, Distance altitude)
		{
			_latitude = latitude;
			_longitude = longitude;
		}

		public Angle Latitude
		{
			get
			{
				return _latitude;
			}
			set
			{
				_latitude = value;
			}
		}

		public Angle Longitude
		{
			get
			{
				return _longitude;
			}
			set
			{
				_longitude = value;
			}
		}

		public Distance Altitude
		{
			get
			{
				return _altitude;
			}
			set
			{
				_altitude = value;
			}
		}

	}
}
