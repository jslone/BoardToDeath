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
			character.Move(Offset);
			Offset += Space;
		}
	}
}
