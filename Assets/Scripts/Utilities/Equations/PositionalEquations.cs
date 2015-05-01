using UnityEngine;
using System.Collections;

public class PositionalEquations : MonoBehaviour {
	public Equation equation;

	public float position;
	public float positionScale;
	private float lastValue;
	public float value { get; private set; }
	public float delta { get { return value - lastValue; } }

	// Use this for initialization
	void Start () {
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		lastValue = value;
		position = transform.localPosition.y * positionScale; // TODO: don't hard-code to y
		value = equation.eval(position);
	}

	public void Reset() {
		lastValue = equation.eval(0);
		value = lastValue;
		position = 0;
	}
}
