using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Lvl3Mage.InterpolationToolkit.Splines
{
	[Serializable]
	public class VibrationSplineCreator : I4PointSplineFactory, I2PointSplineFactory
	{
		[SerializeField] int vibrationCount;
		[SerializeField] float magnitude;
		[SerializeField] bool randomize = true;
		public class VibrationSpline : ISpline
		{
			readonly int vibrationCount;
			readonly float start;
			readonly float control1;
			readonly float control2;
			readonly float end;
			readonly float[] points;
			readonly int seed;

			public VibrationSpline(int vibrationCount, float[] points, int seed = 0)
			{
				this.vibrationCount = vibrationCount;
				this.points = points;
				this.seed = seed;
			}
			public float Evaluate(float t)
			{
				int tSegment = (int)(t * vibrationCount);
				Random random = new(tSegment+seed);
				float[] influences = new float[4];
				
				
				for (int i = 0; i < influences.Length; i++){
					influences[i] = (float)random.NextDouble();
				}
				float sumInv = 1/influences.Sum();

				for (int i = 0; i < influences.Length; i++){
					influences[i] *= sumInv;
				}
				
				float val = 0;
				for (int i = 0; i < points.Length; i++){
					val += points[i] * influences[i];
				}

				return val;
			}
		}
		public ISpline CreateSpline(float control1, float control2, float control3, float control4)
		{
			float[] points = {control1, control2, control3, control4};
			return CreateSpline(points);
		}

		public ISpline CreateSpline(float control1, float control2)
		{
			float[] points = {control1, control2};
			return CreateSpline(points);
		}

		ISpline CreateSpline(float[] points)
		{
			for (int i = 0; i < points.Length; i++){
				points[i] *= magnitude;
			}
			int seed = randomize ? new Random().Next() : 0;
			return new VibrationSpline(vibrationCount, points, seed);
		}
	}
}