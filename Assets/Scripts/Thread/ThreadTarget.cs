using UnityEngine;
using System.Collections;

public class ThreadTarget : Target {
	int cutHash = Animator.StringToHash("Cut");

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Cut() {
		gameObject.GetComponentInChildren<Animator>().SetTrigger(cutHash);
		Thread thread = gameObject.GetComponentInChildren<Thread>();
		if(thread) {
			thread.Cut();
		}
	}

	public override void DoSomething() {
		FindObjectOfType<Fate>().UseTarget(this);
	}
}
