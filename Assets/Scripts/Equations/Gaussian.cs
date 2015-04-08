using UnityEngine;
using System.Collections;

// f(x) = Height * e^(-(x - Midpoint)^2 / 2 * Width^2)
public class Gaussian : Equation {
	public float Height;
	public float Midpoint;
	public float Width;

	public override float f (float x) {
		float sqrt_top = x - Midpoint;
		float bottom = 2.0f * Width * Width;
		return Height * Mathf.Exp(-(sqrt_top * sqrt_top) / bottom);
	}
}
