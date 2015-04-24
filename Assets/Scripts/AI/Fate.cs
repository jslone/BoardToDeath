using UnityEngine;
using System.Collections;

public class Fate : Commandable {
	public MoveCharacter move;
	public float Offset = 0.5f;

	public ThreadTarget Target;
	public AudioSource CutSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Target) {
			Vector3 target = move.transform.position;
			float distance = Target.transform.position.x - target.x;
			distance += -Mathf.Sign(distance) * Offset;
			target.x += distance;
			move.Move(target);

			if(Mathf.Abs(distance) < 0.01f) {
				if((Target.transform.position.x - transform.position.x)*transform.localScale.x > 0)
					Flip ();
				CutSound.Play();
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
