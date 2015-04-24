using UnityEngine;
using System.Collections;

public class Patience : MonoBehaviour {
	public float LifeSpan { get; private set; }
	public float TTL;

	void Awake() {
		LifeSpan = TTL;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TTL -= GameTime.deltaTime.time;
		if(TTL < 0) {
			Turn();
		}
	}

	void Turn() {
		GetComponent<Animator>().SetTrigger("monster");
	}

	void Rage() {
		Souls.AddMonster(GetComponent<RPGCharacter>());
		Destroy(gameObject);
	}
}
