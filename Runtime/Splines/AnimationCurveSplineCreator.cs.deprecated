using System;
using UnityEngine;

namespace Lvl3Mage.InterpolationToolkit.Splines
{
	[Serializable]
	public class AnimationCurveSplineCreator : I4PointSplineFactory
	{
		[SerializeField] AnimationCurve tangent1Influence;
		[SerializeField] AnimationCurve tangent2Influence;
		public class AnimationCurveSpline : ISpline
		{
			AnimationCurve tangent1Influence;
			AnimationCurve tangent2Influence;
			readonly float start;
			readonly float control1;
			readonly float control2;
			readonly float end;

			public AnimationCurveSpline(AnimationCurve tangent1Influence, AnimationCurve tangent2Influence, float start, float control1, float control2, float end)
			{
				this.tangent1Influence = tangent1Influence;
				this.tangent2Influence = tangent2Influence;
				this.start = start;
				this.control1 = control1;
				this.control2 = control2;
				this.end = end;
			}
			public float Evaluate(float t)
			{
				float influence1 = (1 - t);
				float influence2 = tangent1Influence.Evaluate(t);
				float influence3 = tangent2Influence.Evaluate(t);
				float influence4 = t;
				float normalizationFactor = 1/(influence1 + influence2 + influence3 + influence4);
				influence1 *= normalizationFactor;
				influence2 *= normalizationFactor;
				influence3 *= normalizationFactor;
				influence4 *= normalizationFactor;
					
				return start*influence1 + control1*influence2 + control2*influence3 + end*influence4;
			}
		}

		public ISpline CreateSpline(float control1, float control2, float control3, float control4)
		{
			return new AnimationCurveSpline(tangent1Influence, tangent2Influence, control1, control2, control3,
				control4);
		}
	}
}