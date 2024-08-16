namespace Lvl3Mage.InterpolationToolkit.Splines
{
	public class Spline4PointFactoryProvider : I4PointSplineFactory
	{
		public delegate ISpline SplineCreator(float control1, float control2, float control3, float control4);

		readonly SplineCreator creator;
		public Spline4PointFactoryProvider(SplineCreator creator)
		{
			this.creator = creator;
		}
		public ISpline CreateSpline(float control1, float control2, float control3, float control4)
		{
			return creator(control1, control2, control3, control4);
		}
	}
}