using UnityEngine;
using System.Collections;

public abstract class RandomEvent : MonoBehaviour {
	public TimedEquations probability;
	
	// Update is called once per frame
	void Update () {
		float p = probability.value * Time.deltaTime;
		if(Random.value < p) {
			Event();
		}
	}

	protected abstract void Event();

}