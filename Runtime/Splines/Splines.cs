namespace Lvl3Mage.InterpolationToolkit.Splines
{
	public interface ISpline
	{
		public float Evaluate(float t);
	}
	public interface I4PointSplineFactory
	{
		public ISpline CreateSpline(float control1, float control2, float control3, float control4);

		public ISpline[] CreateSplines(float[] control1, float[] control2, float[] control3, float[] control4)
		{
			ISpline[] splines = new ISpline[control1.Length];
			for (int i = 0; i < splines.Length; i++)
			{
				splines[i] = CreateSpline(control1[i], control2[i], control3[i], control4[i]);
			}
			return splines;
		}
	}
	public interface I2PointSplineFactory
	{
		public ISpline CreateSpline(float control1, float control2);

		public ISpline[] CreateSplines(float[] control1, float[] control2)
		{
			ISpline[] splines = new ISpline[control1.Length];
			for (int i = 0; i < splines.Length; i++)
			{
				splines[i] = CreateSpline(control1[i], control2[i]);
			}
			return splines;
		}
	}
}