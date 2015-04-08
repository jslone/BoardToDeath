using UnityEngine;
using System.Collections;

// f(x) = ae^x + b
public class Exponential : Equation {
	public override float f(float x) {
		return Mathf.Exp(x);
	}
}
