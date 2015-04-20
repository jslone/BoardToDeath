using UnityEngine;
using System.Collections;

public class TimedEquations : MonoBehaviour {
	public Equation equation;

	private float time;
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
		time += GameTime.deltaTime.time;
		value = equation.eval(time);
	}

	public void Reset() {
		lastValue = equation.eval(0);
		value = lastValue;
		time = 0;
	}
}
