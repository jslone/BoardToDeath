using UnityEngine;
using System.Collections;

//                     Height
// f(x) = --------------------------------
//         1 + e^(-Slope * (x - Midpoint)
public class Logistic : Equation {
	public float Height;
	public float Midpoint;
	public float Slope;

	public override float f (float x) {
		return Height / (1 + Mathf.Exp(-Slope * (x - Midpoint)));
	}
}
