using UnityEngine;
using System.Collections;

public class Logarithmic : Function {
	public float Scalar;
	public float Intercept;
	public float Offset;

	public override float eval(float x) {
		return Scalar * Mathf.Log(x + Offset) + Intercept;
	}
}
