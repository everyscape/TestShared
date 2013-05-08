using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveryScape.Utilities.Geographic
{
	public class Angle
	{
		private double _angularValue;

		/// <summary>
		/// Returns an Angle with the default value of 0 and units DecimalDegrees.
		/// </summary>
		public Angle()
		{
			setAngle(0, Units.Angular.DecimalDegrees);
		}

		/// <summary>
		/// Returns an Angle with units set to the default DecimalDegrees.
		/// </summary>
		/// <param name="angularValue">The value for the angle.</param>
		public Angle(double angularValue)
		{
			setAngle(angularValue, Units.Angular.DecimalDegrees);
		}

		/// <summary>
		/// Returns an Angle with units set to angularUnits.
		/// </summary>
		/// <param name="angularValue">The value for the angle.</param>
		/// <param name="units">The units for the angle.</param>
		public Angle(double angularValue, Units.Angular angularUnits)
		{
			setAngle(angularValue, angularUnits);
		}


		/// <summary>
		/// Sets the value and units of the angle.
		/// </summary>
		/// <param name="angularValue">The value for the angle.</param>
		/// <param name="angularUnits">The units for the angle.</param>
		public void setAngle(double angularValue, Units.Angular angularUnits)
		{
			if (angularUnits == Units.Angular.Radians)
			{
				_angularValue = angularValue * radToDeg;
			}
			else
			{
				_angularValue = angularValue;
			}

		}

		/// <summary>
		/// The value of the angle in DecimalDegrees
		/// </summary>
		public double Degrees
		{
			get
			{
				return _angularValue;
			}
		}


		/// <summary>
		/// The value of the angle in Radians
		/// </summary>
		public double Radians
		{
			get
			{
				return _angularValue * degToRad;
			}
		}

		#region Angular Conversions
		// Conversion Constants
		private const double radToDeg = 180 / Math.PI;
		private const double degToRad = Math.PI / 180;

		#endregion

	}
}
