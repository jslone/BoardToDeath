using UnityEngine;
using System.Collections;

public class Patience : MonoBehaviour {
	public float TimeWillWait {
		set {
			TTL = value;
			started = true;
		}
	}

	private bool started = false;
	private float TTL = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(started) {
			TTL -= Time.deltaTime;
			if(TTL < 0) {
				Rage();
			}
		}
	}

	void Rage() {
		Souls.monsters++;
		Destroy(gameObject);
	}
}
