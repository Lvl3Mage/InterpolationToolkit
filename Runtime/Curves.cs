using UnityEngine;

namespace Lvl3Mage.InterpolationToolkit
{
	public static class Curves
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
		/// <param name="halfLife">The value halflife</param>
		/// <returns>
		/// Returns a value decaying 1 to 0. The value is halved at each halfLife.
		/// </returns>
		public static float ValueDecay(float value, float halfLife)
		{
			const float half = 0.5f;
			float exponent = value / halfLife;
			return Mathf.Pow(half, exponent);
		}
		/// <summary>
		/// Calculates a value activation curve.
		/// </summary>
		/// <param name="val">An input value in range 0 to 1</param>
		/// <param name="slope">
		/// A slope value in range -inf to +inf
		/// </param>
		/// <returns>
		/// Returns a value activated 0 to 1 when slope is positive and 1 to 0 when slope is negative with the activation centered at 0.5.
		/// </returns>
		public static float ValueActivation(float val, float slope){
			val = Mathf.Clamp01(val);

			bool inverted = false;
			if(slope < 0){
				inverted = true;
				slope *= -1;
			}

			float elevated = Mathf.Pow(val,slope);
			float invertedElev = Mathf.Pow(1-val, slope);
			float result = elevated/(elevated+invertedElev);

			if(inverted){
				result = 1 - result;
			}
			return result;
		}
	}
}