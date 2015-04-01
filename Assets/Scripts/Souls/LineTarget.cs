using UnityEngine;
using System.Collections;

public class LineTarget : Target {
	public Line to;
	public Line from;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void DoSomething() {
		if(from.Queue.Count > 0) {
			MoveCharacter m = from.Queue.Dequeue();
			to.Queue.Enqueue(m);
		}
	}
}
