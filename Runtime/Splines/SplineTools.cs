namespace Lvl3Mage.InterpolationToolkit.Splines
{
	public static class SplineTools
	{
		public static float[] EvaluateSplines(ISpline[] splines, float t)
		{
			float[] values = new float[splines.Length];
			for (int i = 0; i < splines.Length; i++){
				values[i] = splines[i].Evaluate(t);
			}
			return values;
		}
		public static float Cubic (float a, float b, float c, float d, float x)
		{
			float t2 = x * x;
			float t3 = t2 * x;
			return t3 * a + t2 * b + x * c + d;
		}
		public static float SmoothStep(float control1, float control2, float t)
		{
			float a = 0;
			float b = 0;
			float c = 3 * (control2 - control1);
			float d = control1;
			return Cubic(a,b,c,d, t);
		}
	}
}