using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterLine : MonoBehaviour {
	public float Speed = 1.0f;
	public LinkedList<Vector3> targets = new LinkedList<Vector3>();
	
	// Use this for initialization
	void Start () {
		
	}
	
	void Update() {
		if(targets.Count > 0) {
			Vector3 target = targets.First.Value;
			Vector3 pos = transform.position;
			
			Vector3 delta = (target - pos).normalized * Speed * GameTime.deltaTime.time;
			
			delta = Vector3.ClampMagnitude(delta, (target - pos).magnitude);
			
			if(delta.x * transform.lossyScale.x > 0) {
				Flip();
			}
			
			pos += delta;
			transform.position = pos;
			
			if(pos == target) {
				do {
					targets.RemoveFirst();
				} while(targets.Count > 0 && targets.First.Value == pos);
			}
			
		}
	}
	
	public void Move(Vector3 target) {
		transform.position = target;
		//targets.AddLast(target);
		
	}
	
	void Flip() {
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
