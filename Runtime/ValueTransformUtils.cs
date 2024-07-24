using UnityEngine;

namespace Interpolation
{
	public static class ValueTransformUtils
	{
		/// <summary>
		/// Calculates a symmetrical curved value.
		/// </summary>
		/// <param name="t">An input value in range 0 to 1</param>
		/// <param name="slope">A slope value in range -inf to +inf</param>
		/// <returns>
		/// When slope is 0, returns t.
		/// When slope is positive, the curve is flat at the start and gradually steepens towards the end.
		/// When slope is negative, the curve is sharp at the start and gradually flattens towards the end.
		/// </returns>

		public static float SymmetricalCurve(float t, float slope)
		{
			t = Mathf.Clamp01(t);
			//Transforms decaySpeed from [-1, +inf] to [-inf, +inf] 
			float c = Mathf.Clamp(-(1 / (slope - 1)) + 1, slope, 0);
			return t / (c * (1 - t) + 1);
		}

		/// <summary>
		/// Calculates a value decay curve.
		/// </summary>
		/// <param name="value">An input value in range 0 to +inf</param>
		/// <param name="halfPoint">A half-point value in range 0 to +inf</param>
		/// <returns>
		/// Returns a value decaying 1 to 0.
		/// When value is 0, returns 1.
		/// When value equals halfPoint, returns 0.5.
		/// When value is infinite, returns 0.
		/// </returns>
		public static float ValueDecay(float value, float halfPoint)
		{
			return 1/(value*(1/halfPoint) + 1);
		}
	}
}