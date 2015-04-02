using UnityEngine;
using System.Collections;

public class TraceEquation : MonoBehaviour {
	public TimedEquations Position;
	public Vector3 Direction;
	public bool Flipable;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += Direction * Position.delta;
		if(Flipable && Position.delta * transform.lossyScale.x < 0) {
			Flip();
		}
	}

	void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
