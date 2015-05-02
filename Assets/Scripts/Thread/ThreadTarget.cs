using UnityEngine;
using System.Collections;

public class ThreadTarget : Target {
	int cutHash = Animator.StringToHash("Cut");
	Color lastColor = Color.black;

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

	public void SetColor(Color c) {
		lastColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
		transform.GetChild(0).GetComponent<SpriteRenderer>().color = c;
	}

	public void ResetColor() {
		transform.GetChild(0).GetComponent<SpriteRenderer>().color = lastColor;
	}

	public override void DoSomething() {
		FindObjectOfType<Fate>().UseTarget(this);
	}
}
