using UnityEngine;
using System.Collections;

public class TraceEquation : MonoBehaviour {
	public TimedEquations Position;
	public Vector3 Direction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition += Direction * Position.delta;
	}
}
