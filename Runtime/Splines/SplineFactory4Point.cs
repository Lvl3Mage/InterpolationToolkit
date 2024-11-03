namespace Lvl3Mage.InterpolationToolkit.Splines
{
	public class Spline4PointFactoryProvider<T> : I4PointSplineFactory<T>
	{
		public delegate ISpline<T> SplineCreator(T control1, T control2, T control3, T control4);

		readonly SplineCreator creator;
		public Spline4PointFactoryProvider(SplineCreator creator)
		{
			this.creator = creator;
		}
		public ISpline<T> CreateSpline(T control1, T control2, T control3, T control4)
		{
			return creator(control1, control2, control3, control4);
		}
	}
}