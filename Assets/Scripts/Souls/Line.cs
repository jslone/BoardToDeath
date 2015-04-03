using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour {
	private Queue<CharacterLine> Queue = new Queue<CharacterLine>();
	public float Space;
	public int Capacity;
	public int Length { get { return Queue.Count; }}

	// Use this for initialization
	void Start () {
	
	}
	
	public void Add(CharacterLine character) {
		Vector3 linePos = transform.position;
		linePos.x += Space * Queue.Count;

		Queue.Enqueue(character);

		Vector3 lineEnd = transform.position;
		lineEnd.x += Space * Capacity;

		character.Move(lineEnd);
		character.Move(linePos);
	}

	public CharacterLine Remove() {
		CharacterLine character = Queue.Dequeue();
		UpdatePositions();
		return character;
	}

	void UpdatePositions() {
		float Offset = transform.position.x;
		foreach(CharacterLine character in Queue) {
			Vector3 target = transform.position;
			target.x = Offset;

			character.Move(target);
			
			Offset += Space;
		}
	}
}
