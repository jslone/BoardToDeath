using UnityEngine;
using System.Collections;

public class UIHealth : MonoBehaviour {
	public bool invert;
	public RPGCharacter character;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 scale = transform.localScale;
		if(invert) {
			scale.y = 1 - character.Health.x / character.Health.y;
		} else {
			scale.x = character.Health.x / character.Health.y;
		}
		transform.localScale = scale;
	}
}
