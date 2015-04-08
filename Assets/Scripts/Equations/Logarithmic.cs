using UnityEngine;
using System.Collections;

public class Logarithmic : Equation {

	public override float f (float x) {
		return Mathf.Log(x);
	}
}
