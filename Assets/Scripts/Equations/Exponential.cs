﻿using UnityEngine;
using System.Collections;

// f(x) = ae^x + b
public class Exponential : Equation {
	public float Scalar;
	public float Intercept;

	public override float eval(float x) {
		return Scalar * Mathf.Exp(x) + Intercept;
	}
}