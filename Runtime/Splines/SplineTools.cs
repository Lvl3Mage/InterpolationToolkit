using System;

namespace Lvl3Mage.InterpolationToolkit.Splines
{
	public static class SplineTools
	{
		public static T[] EvaluateSplines<T>(ISpline<T>[] splines, float t)
		{
			T[] values = new T[splines.Length];
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

	public static class ComponentSplineTools
	{
		/// <summary>
		/// Converts an array of values to an array of component arrays
		/// </summary>
		/// <param name="values">
		///	The values to convert
		/// </param>
		/// <param name="toComponents">
		///	The function to convert a value to a component array
		/// </param>
		/// <typeparam name="T">
		///	The type of the values
		/// </typeparam>
		/// <returns>
		///	An array of component arrays
		/// </returns>
		public static float[][] ValuesToComponentsBatch<T>(T[] values, ToComponents<T> toComponents)
		{
			float[][] componentValues = new float[values.Length][];
			for (int i = 0; i < values.Length; i++)
			{
				componentValues[i] = toComponents(values[i]);
			}
			return componentValues;
		}

		/// <summary>
		/// Runs a horizontal kernel on a batch of component arrays
		/// </summary>
		/// <param name="inputBatch">
		/// The batch of component arrays to process
		/// </param>
		/// <param name="kernel">
		/// The kernel to run on each component array, the size of the kernel output must match the amount of values in the input batch.
		/// The kernel will run for each component of the batch
		/// </param>
		/// <returns>
		/// The processed batch of component arrays
		/// </returns>
		public static float[][] RunHorizontalKernel(float[][] inputBatch, Func<float[], float[]> kernel)
		{
			if(inputBatch.Length == 0){
				return Array.Empty<float[]>();
			}

			float[][] processed = new float[inputBatch.Length][];

			int componentCount = inputBatch[0].Length;
			for (int i = 0; i < processed.Length; i++){
				processed[i] = new float[componentCount];
			}

			for (int component = 0; component < componentCount; component++){
				float[] componentValues = new float[inputBatch.Length];
				for (int value = 0; value < inputBatch.Length; value++)
				{
					componentValues[value] = inputBatch[value][component];
				}

				componentValues = kernel(componentValues);

				for(int value = 0; value < componentValues.Length; value++)
				{
					processed[value][component] = componentValues[value];
				}
			}
			return processed;
		}
	}
}