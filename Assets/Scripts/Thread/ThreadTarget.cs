using UnityEngine;
using System.Collections;

public class ThreadTarget : Target {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Cut() {
		Thread thread = gameObject.GetComponentInChildren<Thread>();
		if(thread) {
			thread.Cut();
		}
	}

	public override void DoSomething() {
		FindObjectOfType<Fate>().UseTarget(this);
	}
}
