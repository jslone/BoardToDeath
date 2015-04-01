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
		lastValue = equation.eval(0);
		value = lastValue;
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		lastValue = value;
		time += Time.deltaTime;
		value = equation.eval(time);
	}
}
