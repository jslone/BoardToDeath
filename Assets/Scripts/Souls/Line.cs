using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Line : MonoBehaviour {
	private LinkedList<CharacterLine> Queue = new LinkedList<CharacterLine>();
	public float Space;
	public int Capacity;
	public int Length
	{
		get
		{
			Prune();
			return Queue.Count;
		}
	}

	// Use this for initialization
	void Start () {
	
	}

	void Update() {
		Prune();
		UpdatePositions();
	}
	
	public void Add(CharacterLine character) {
		Vector3 linePos = transform.position;
		linePos.x += Space * Queue.Count;

		Queue.AddLast(character);

		Vector3 lineEnd = transform.position;
		lineEnd.x += Space * Capacity;

		character.Move(lineEnd);
		character.Move(linePos);
	}

	public CharacterLine Remove() {
		Prune();
		CharacterLine character = Queue.First.Value;
		Queue.RemoveFirst();
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

	void Prune() {
		LinkedListNode<CharacterLine> node = Queue.First;
		while(node != Queue.Last) {
			LinkedListNode<CharacterLine> tmp = node.Next;
			if(!node.Value || !node.Value.enabled) {
				Queue.Remove(node);
			}
			node = tmp;
		}
		if(Queue.Count > 0 && !node.Value) {
			Queue.Remove(node);
		}
	}
}
