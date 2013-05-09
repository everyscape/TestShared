using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryScape.Utilities.Geographic
{
	public class Distance
	{
		private double _distanceValue;

		/// <summary>
		/// Returns a Distance object with default value of 0 kilometers
		/// </summary>
		public Distance()
		{
			setDistance(0, Units.Linear.Kilometers);
		}

		/// <summary>
		/// Returns a Distance object with the specified value, defaulting to kilometers
		/// </summary>
		/// <param name="distance">The distance value</param>
		public Distance(double distance)
		{
			setDistance(distance, Units.Linear.Kilometers);
		}


		/// <summary>
		/// Returns a Distance object with the specified value and units.
		/// </summary>
		/// <param name="distance">The distance value</param>
		/// <param name="units">The distance units</param>
		public Distance(double distance, Units.Linear units)
		{
			setDistance(distance, units);
		}

		/// <summary>
		/// Sets the value of the distance
		/// </summary>
		/// <param name="distance">The distance value</param>
		public void setDistance(double distance)
		{
			setDistance(distance, Units.Linear.Kilometers);
		}

		/// <summary>
		/// Sets the value of the distance in the specified units
		/// </summary>
		/// <param name="distance">The distance value</param>
		/// <param name="units">The distance units</param>
		public void setDistance(double distance, Units.Linear units)
		{
			if (units == Units.Linear.Miles)
			{
				_distanceValue = distance * milesToKm;
			}
			else
			{
				_distanceValue = distance;
			}
		}

		/// <summary>
		/// The value in kilometers
		/// </summary>
		public double Kilometers
		{
			get
			{
				return _distanceValue;
			}
		}

		/// <summary>
		/// The value in miles
		/// </summary>
		public double Miles
		{
			get
			{
				return _distanceValue * kmToMiles;
			}
		}

		// Conversion Constants
		private const double kmToMiles = 0.621371;
		private const double milesToKm = 1.60934;
	}
}
