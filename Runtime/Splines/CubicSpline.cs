namespace Lvl3Mage.InterpolationToolkit.Splines
{
	public class CubicSpline : ISpline
	{
		public CubicSpline(float a, float b, float c, float d)
		{
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
		}
		float a, b, c, d;
		public static CubicSpline Hermite(float control1, float tangent1, float tangent2, float control2)
		{
			float a = 2 * control1 - 2 * control2 + tangent1 + tangent2;
			float b = -3 * control1 + 3 * control2 - 2 * tangent1 - tangent2;
			float c = tangent1;
			float d = control1;
			return new CubicSpline(a, b, c, d);
		}
		public static CubicSpline SmoothStepData(float control1, float control2)
		{
			float a = 0;
			float b = 0;
			float c = 3 * (control2 - control1);
			float d = control1;
			return new CubicSpline(a, b, c, d);
		}

		public float Evaluate(float t)
		{
			return SplineTools.Cubic(a,b,c,d, t);
		}
	}
}