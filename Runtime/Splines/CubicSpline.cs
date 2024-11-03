using System;

namespace Lvl3Mage.InterpolationToolkit.Splines
{
	public class CubicSpline<T> : ISpline<T>
	{
		public CubicSpline(float[] a, float[] b, float[] c, float[] d, FromComponents<T> fromComponents)
		{
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
			this.fromComponents = fromComponents;
		}

		public CubicSpline(T a, T b, T c, T d, ToComponents<T> toComponents, FromComponents<T> fromComponents)
		{
			this.a = toComponents(a);
			this.b = toComponents(b);
			this.c = toComponents(c);
			this.d = toComponents(d);
			this.fromComponents = fromComponents;
		}

		readonly float[] a, b, c, d;
		readonly FromComponents<T> fromComponents;

		public static readonly Func<float[], float[]> HermiteKernel = values => {
			float a = 2 * values[0] - 2 * values[3] + values[1] + values[2];
			float b = -3 * values[0] + 3 * values[3] - 2 * values[1] - values[2];
			float c = values[1];
			float d = values[0];
			return new[]{ a, b, c, d };
		};
		public static readonly Func<float[], float[]> SmoothStepKernel = values => {
			float a = 0;
			float b = 0;
			float c = 3 * (values[1] - values[0]);
			float d = values[0];
			return new[]{ a, b, c, d };
		};

		public static CubicSpline<T> FromKernel(T[] values, ToComponents<T> toComponents,
			FromComponents<T> fromComponents, Func<float[], float[]> kernel)
		{
			float[][] valueComponents = ComponentSplineTools.ValuesToComponentsBatch(values, toComponents);
			float[][] cubicData = ComponentSplineTools.RunHorizontalKernel(valueComponents, kernel);
			return new CubicSpline<T>(cubicData[0], cubicData[1], cubicData[2], cubicData[3], fromComponents);
		}

		public static CubicSpline<T> Hermite(T control1, T vel1, T vel2, T control2, ToComponents<T> toComponents,
			FromComponents<T> fromComponents)
		{
			return FromKernel(
				new[]{
					control1, vel1, vel2, control2
				},
				toComponents, fromComponents, HermiteKernel);
		}

		public static CubicSpline<T> SmoothStep(T control1, T control2, ToComponents<T> toComponents,
			FromComponents<T> fromComponents)
		{
			return FromKernel(new[]{control1,control2}, toComponents, fromComponents, SmoothStepKernel);
		}

		public T Evaluate(float t)
		{
			float[] result = new float[a.Length];
			for (int i = 0; i < a.Length; i++){
				result[i] = SplineTools.Cubic(a[i], b[i], c[i], d[i], t);
			}

			return fromComponents(result);
		}
	}

}