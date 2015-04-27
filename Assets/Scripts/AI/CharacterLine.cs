using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterLine : MoveCharacter {
	public ParticleSystem particles;

	public void Teleport(Vector3 target) {
		particles.Play();
		transform.position = target;
	}
	
	void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
