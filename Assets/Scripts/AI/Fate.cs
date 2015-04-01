using UnityEngine;
using System.Collections;

public class Fate : Commandable {
	public MoveCharacter move;
	public float Offset = 0.5f;

	public ThreadTarget Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Target) {
			move.Move(Target.transform.position.x + Offset);

			if(Mathf.Abs((Target.transform.position.x + Offset) - transform.position.x) < 0.01f) {
				if(transform.localScale.x < 0) {
					Flip();
				}
				Target.Cut();
				Target = null;
			}
		}
	}

	void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public override void UseTarget (Target t) {
		ThreadTarget target = t as ThreadTarget;
		if(target) {
			Target = target;
		}
	}
}
