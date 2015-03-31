using UnityEngine;
using System.Collections;

//                     Height
// f(x) = --------------------------------
//         1 + e^(-Slope * (x - Midpoint)
public class Logistic : Function {
	float Height;
	float Midpoint;
	float Slope;

	public override float eval (float x) {
		return Height / (1 + Mathf.Exp(-Slope * (x - Midpoint)));
	}
}
