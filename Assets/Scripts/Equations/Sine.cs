using UnityEngine;
using System.Collections;

public class Sine : Equation {
	public float Amplitude;
	public float Period;
	public float Offset;

	public override float eval (float x) {
		return Amplitude * Mathf.Sin(2 * Mathf.PI * x / Period + Offset);
	}
}
