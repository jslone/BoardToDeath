using UnityEngine;
using System.Collections;

public class GameTime {
	public static bool paused = false;
	public static bool done = false;
	public static float scale = 1.0f;

	public struct deltaTime
	{
		public static float unscaled
		{
			get { return paused || done ? 0 : Time.deltaTime; }
		}
		public static float unpaused
		{
			get { return scale * Time.deltaTime; }
		}
		public static float time
		{
			get { return paused || done ? 0 : scale * Time.deltaTime; }
		}
	}
}
