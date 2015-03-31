using UnityEngine;
using System.Collections;

// y = sum from i = 0 to n of Coefficients[i] * x^i
public class Polynomial : Function {
	public float[] Coefficients;

	public override float eval(float x) {
		float y = 0.0f;
		float xn = 1.0f;

		foreach(float a in Coefficients) {
			y += a * xn;
			xn *= x;
		}

		return y;
	}
}
