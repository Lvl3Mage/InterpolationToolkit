using System;

namespace Lvl3Mage.InterpolationToolkit
{
	public delegate T Interpolator<T>(T a, T b, float t);

	//todo: update to use the generic interpolator delegate
	public class Interpolate
	{
		/// <summary>
		/// Linearly interpolates between two values.
		/// </summary>
		/// <param name="a">
		/// The start value.
		/// </param>
		/// <param name="b">
		/// The end value.
		/// </param>
		/// <param name="t">
		/// The interpolation factor. Should be between 0 and 1.
		/// </param>
		/// <returns></returns>
		public static float Linear(float a, float b, float t)
		{
			return a + (b - a) * t;
		}
		public static float SmoothStep(float a, float b, float t)
		{
			return Linear(a, b, t * t * (3 - 2 * t));
		}

		/// <summary>
		/// Performs bilinear interpolation between four values.
		/// </summary>
		/// <param name="a">
		/// The value in the bottom left corner.
		/// </param>
		/// <param name="b">
		/// The value in the bottom right corner.
		/// </param>
		/// <param name="c">
		/// The value in the top left corner.
		/// </param>
		/// <param name="d">
		/// The value in the top right corner.
		/// </param>
		/// <param name="tx">
		/// The interpolation factor in the x direction.
		/// </param>
		/// <param name="ty">
		/// The interpolation factor in the y direction.
		/// </param>
		/// <param name="lerpFunc">
		/// The interpolation function to use. Takes two values and an interpolation factor and returns the interpolated value.
		/// Will default to linear interpolation if not provided.
		/// </param>
		/// <returns>
		/// The interpolated value.
		/// </returns>
		public static float Bilinear(float a, float b, float c, float d, float tx, float ty, Func<float,float,float,float> lerpFunc = null)
		{
			lerpFunc ??= Linear;

			return lerpFunc(lerpFunc(a, b, tx), lerpFunc(c, d, tx), ty);
		}


		/// <summary>
		/// Performs bilinear interpolation between four generic values.
		/// </summary>
		/// <param name="a">
		/// The value in the bottom left corner.
		/// </param>
		/// <param name="b">
		/// The value in the bottom right corner.
		/// </param>
		/// <param name="c">
		/// The value in the top left corner.
		/// </param>
		/// <param name="d">
		/// The value in the top right corner.
		/// </param>
		/// <param name="tx">
		/// The interpolation factor in the x direction.
		/// </param>
		/// <param name="ty">
		/// The interpolation factor in the y direction.
		/// </param>
		/// <param name="lerpFunc">
		/// The interpolation function to use. Takes two values and an interpolation factor and returns the interpolated value.
		/// </param>
		/// <returns>
		/// The interpolated value.
		/// </returns>
		public static T Bilinear<T>(T a, T b, T c, T d, float tx, float ty, Func<T, T, float, T> lerpFunc)
		{
			return lerpFunc(lerpFunc(a, b, tx), lerpFunc(c, d, tx), ty);
		}
	}
}