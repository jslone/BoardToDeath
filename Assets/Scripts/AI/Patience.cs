using UnityEngine;
using System.Collections;

public class Patience : MonoBehaviour {
	public static float MAX = 30.0f; // TODO: set max patience per soul type
	private float _timeWillWait;
	public float TimeWillWait {
		get { return _timeWillWait; }
		set
		{
			_timeWillWait = value;
			TTL = value;
			started = true;
		}
	}

	public bool started = false;
	public float TTL = 0.0f;

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
