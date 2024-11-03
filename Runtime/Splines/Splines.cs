namespace Lvl3Mage.InterpolationToolkit.Splines
{
	public delegate float[] ToComponents<T>(T value);
	public delegate T FromComponents<T>(float[] value);
	public interface ISpline<T>
	{
		public T Evaluate(float t);
	}
	public interface I4PointSplineFactory<T>
	{
		public ISpline<T> CreateSpline(T control1, T control2, T control3, T control4);

		public ISpline<T>[] CreateSplines(T[] control1, T[] control2, T[] control3, T[] control4)
		{
			ISpline<T>[] splines = new ISpline<T>[control1.Length];
			for (int i = 0; i < splines.Length; i++)
			{
				splines[i] = CreateSpline(control1[i], control2[i], control3[i], control4[i]);
			}
			return splines;
		}
	}
	public interface I2PointSplineFactory<T>
	{
		public ISpline<T> CreateSpline(T control1, T control2);

		public ISpline<T>[] CreateSplines(T[] control1, T[] control2)
		{
			ISpline<T>[] splines = new ISpline<T>[control1.Length];
			for (int i = 0; i < splines.Length; i++)
			{
				splines[i] = CreateSpline(control1[i], control2[i]);
			}
			return splines;
		}
	}
}