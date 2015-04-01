using UnityEngine;
using System.Collections;

public class Fate : Commandable {
	public float Speed = 1.0f;
	public float Offset = 0.5f;

	public ThreadTarget Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Target) {
			Vector3 pos = transform.position;
			float targetX = Target.transform.position.x + Offset;

			float deltaX = Mathf.Sign(targetX - pos.x) * Speed * Time.deltaTime;

			deltaX = Mathf.Clamp(deltaX, -Mathf.Abs(targetX - pos.x), Mathf.Abs(targetX - pos.x));

			if(deltaX * transform.lossyScale.x > 0) {
				Flip();
			}

			if(Mathf.Abs(deltaX) < 0.01f) {
				if(transform.localScale.x < 0) {
					Flip();
				}
				Target.Cut();
				Target = null;
			}

			pos.x += deltaX;

			transform.position = pos;
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
