using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryScape.Utilities.Geographic
{
	public static class Geographic
	{
		/// <summary>
		/// Returns an angle indicating the bearing of "to" relative to "from".
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static Angle GetBearing(Location from, Location to)
		{
			double a = Math.Sin(to.Longitude.Radians - from.Longitude.Radians) * Math.Cos(to.Latitude.Radians);
			double b = Math.Cos(from.Latitude.Radians) * Math.Sin(to.Latitude.Radians);
			double c = Math.Sin(from.Latitude.Radians) * Math.Cos(to.Latitude.Radians) * Math.Cos(to.Longitude.Radians - from.Longitude.Radians);
			double d = Math.Atan2(a, b - c) % ( 2 * Math.PI);
			return new Angle(d, Units.Angular.Radians);
		}


		/// <summary>
		/// Returns the distance between two locations, ignoring altitude differences. (Haversine formula)
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static Distance GetFlatDistance(Location from, Location to)
		{
			double dLat = to.Latitude.Radians - from.Latitude.Radians;
			double dLong = to.Longitude.Radians - from.Longitude.Radians;

			double a = Math.Pow(Math.Sin(dLat/2), 2) + (Math.Pow(Math.Sin(dLong/2), 2) * Math.Cos(from.Latitude.Radians) * Math.Cos(to.Latitude.Radians));
			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

			Distance RadiusOfEarth = new Distance(RadiusOfEarthKm, Units.Linear.Kilometers);

			return new Distance(c * RadiusOfEarth.Kilometers, Units.Linear.Kilometers);
		}


		/// <summary>
		/// Returns the distance between two locations, taking into account altitude differences.
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static Distance GetActualDistance(Location from, Location to)
		{
			double a = GetFlatDistance(from, to).Kilometers;
			double b = Math.Abs(to.Altitude.Kilometers - from.Altitude.Kilometers);
			double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

			return new Distance(c, Units.Linear.Kilometers);
		}

		/// <summary>
		/// Returns the pitch relative to an idealized horizon of "to" from the perspective of "from".
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static Angle GetRelativePitch(Location from, Location to)
		{
			double x = GetFlatDistance(from, to).Kilometers;
			double y = to.Altitude.Kilometers - from.Altitude.Kilometers;

			return new Angle(Math.Atan2(y, x), Units.Angular.Radians);
		}

		/// <summary>
		/// Returns the yaw necessary to turn "from" to face "to".
		/// </summary>
		/// <param name="heading"></param>
		/// <param name="bearing"></param>
		/// <returns></returns>
		public static Angle GetYaw(Angle fromHeading, Angle toBearing)
		{
			return new Angle(((toBearing.Degrees - fromHeading.Degrees) + 360) % 360, Units.Angular.DecimalDegrees);
		}


		public const double RadiusOfEarthKm = 6371.009;
	}
}
