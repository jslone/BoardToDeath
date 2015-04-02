using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {
	public float Speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	public void Move(Vector3 target) {
		Vector3 pos = transform.position;
		
		Vector3 delta = (target - pos).normalized * Speed * Time.deltaTime;

		delta = Vector3.ClampMagnitude(delta, (target - pos).magnitude);
		
		if(delta.x * transform.lossyScale.x > 0) {
			Flip();
		}
		
		transform.position = pos + delta;
	}

	void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
