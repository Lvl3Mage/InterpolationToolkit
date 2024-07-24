using UnityEngine;

namespace Interpolation
{
	public static class Decay
    {
    	/// <summary>
    	/// Framerate independent decay between 2 values
    	/// </summary>
    	/// <param name="from">Start value</param>
    	/// <param name="to">Target value</param>
    	/// <param name="speed">Speed of the decay, usually a value between 1 and 25</param>
    	/// <param name="deltaTime">Delta time since the last update</param>
    	/// <returns></returns>
    	public static float To(float from, float to, float speed, float deltaTime)
    	{
    		return to+(from-to)*Mathf.Exp(-speed*deltaTime);
    	}
	    /// <summary>
    	/// Framerate independent decay between 2 values
    	/// </summary>
    	/// <param name="from">Start value</param>
    	/// <param name="to">Target value</param>
    	/// <param name="speed">Speed of the decay, usually a value between 1 and 25</param>
    	/// <param name="deltaTime">Delta time since the last update</param>
    	/// <returns></returns>
    	public static float ToZoom(float from, float to, float speed, float deltaTime)
    	{
		    float logA = Mathf.Log(from);
		    float logB = Mathf.Log(to);
    		float result = To(logA, logB, speed, deltaTime);
		    return Mathf.Exp(result);
    	}
    	/// <summary>
    	/// Framerate independent decay between 2 angles
    	/// </summary>
    	/// <param name="from">Start angle</param>
    	/// <param name="to">Target angle</param>
    	/// <param name="speed">Speed of the decay, usually a value between 1 and 25</param>
    	/// <param name="deltaTime">Delta time since the last update</param>
    	/// <returns></returns>
    	public static float ToAngle(float from, float to, float speed, float deltaTime)
    	{
    		float delta = Mathf.DeltaAngle(from,to);
    		float target = from + delta;
    		return To(from, target, speed, deltaTime);
    
    	}
    	/// <summary>
    	/// Framerate independent decay between 2 vectors
    	/// </summary>
    	/// <param name="from">Start vector</param>
    	/// <param name="to">Target vectos</param>
    	/// <param name="speed">Speed of the decay, usually a value between 1 and 25</param>
    	/// <param name="deltaTime">Delta time since the last update</param>
    	/// <returns></returns>
    	public static Vector2 To(Vector2 from, Vector2 to, float speed, float deltaTime)
    	{
    		return to+(from-to)*Mathf.Exp(-speed*deltaTime);
    	}
    	/// <summary>
    	/// Framerate independent decay between 2 vectors
    	/// </summary>
    	/// <param name="from">Start vector</param>
    	/// <param name="to">Target vector</param>
    	/// <param name="speed">Speed of the decay</param>
    	/// <param name="deltaTime">Delta time since the last update</param>
    	/// <returns></returns>
    	public static Vector3 To(Vector3 from, Vector3 to, float speed, float deltaTime)
    	{
    		return to+(from-to)*Mathf.Exp(-speed*deltaTime);
    	}
	    
    }
}