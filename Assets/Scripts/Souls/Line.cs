using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour {
	public Queue<MoveCharacter> Queue = new Queue<MoveCharacter>();
	public float Space;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float Offset = transform.position.x;
		foreach(MoveCharacter character in Queue) {
			Vector3 target = transform.position;
			Vector3 pos = character.transform.position;

			if(Mathf.Abs(pos.y - target.y) > 0.1f) {
				pos.y = target.y;
				character.Move(pos);
			} else {
				target.x = Offset;
				character.Move(target);
			}

			Offset += Space;
		}
	}
}
