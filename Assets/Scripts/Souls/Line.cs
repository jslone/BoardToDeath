using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour {
	private Queue<MoveCharacter> Queue = new Queue<MoveCharacter>();
	public float Space;
	public int Length { get { return Queue.Count; }}

	// Use this for initialization
	void Start () {
	
	}
	
	public void Add(MoveCharacter character) {
		Queue.Enqueue(character);
		Vector3 linePos = transform.position;
		linePos.x += Space * Queue.Count;

		if(character.targets.Count > 0) {
			Vector3 lineEnd = transform.position;
			lineEnd.x = character.targets.First.Value.x;
			character.Move(lineEnd);
		}
		character.Move(linePos);
	}

	public MoveCharacter Remove() {
		MoveCharacter character = Queue.Dequeue();
		UpdatePositions();
		return character;
	}

	void UpdatePositions() {
		float Offset = transform.position.x;
		foreach(MoveCharacter character in Queue) {
			Vector3 target = transform.position;
			target.x = Offset;

			character.Move(target);
			
			Offset += Space;
		}
	}
}
