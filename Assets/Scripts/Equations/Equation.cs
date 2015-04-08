using UnityEngine;
using System.Collections;

// f(x) = eval(x)
public abstract class Equation : MonoBehaviour {
	public float Scale = 1.0f;
	public Vector2 Offset;

	public float eval(float x) {
		return Scale * f (x + Offset.x) + Offset.y;
	}
	public abstract float f(float x);
}
