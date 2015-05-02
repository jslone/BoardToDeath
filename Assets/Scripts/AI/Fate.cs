using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fate : Commandable {
	public MoveCharacter move;
	public float Offset = 0.5f;

	public Color queueColor;

	private Queue<ThreadTarget> Targets = new Queue<ThreadTarget>();
	public AudioSource CutSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Targets.Count > 0) {
			ThreadTarget Target = Targets.Peek();
			Vector3 target = move.transform.position;
			float distance = Target.transform.position.x - target.x;
			distance += -Mathf.Sign(distance) * Offset;
			target.x += distance;
			move.Move(target);

			if(Mathf.Abs(distance) < 0.01f) {
				if((Target.transform.position.x - transform.position.x)*transform.localScale.x > 0)
					Flip ();
				CutSound.Play();
				GetComponent<Animator>().SetTrigger("cut");
				Target.Cut();
				Target.SetColor(Color.black);
				Targets.Dequeue();
			}
		}
	}

	public void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public override void UseTarget (Target t) {
		ThreadTarget target = t as ThreadTarget;
		if(target) {
			if(Targets.Contains(target)) {
				foreach(ThreadTarget old in Targets) {
					old.ResetColor();
				}
				Targets.Clear();
			}
			target.SetColor(queueColor);
			Targets.Enqueue(target);
		}
	}
}
