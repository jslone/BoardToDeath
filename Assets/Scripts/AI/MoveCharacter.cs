using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {
	public float Speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	public void Move(float targetX) {
		Vector3 pos = transform.position;
		
		float deltaX = Mathf.Sign(targetX - pos.x) * Speed * Time.deltaTime;
		
		deltaX = Mathf.Clamp(deltaX, -Mathf.Abs(targetX - pos.x), Mathf.Abs(targetX - pos.x));
		
		if(deltaX * transform.lossyScale.x > 0) {
			Flip();
		}
		
		pos.x += deltaX;
		
		transform.position = pos;
	}

	void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
