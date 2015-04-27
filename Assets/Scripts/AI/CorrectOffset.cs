using UnityEngine;
using System.Collections;

public class CorrectOffset : MonoBehaviour {
	public float Speed = 1.0f;
	private Vector3 dir;

	// Use this for initialization
	void Start () {
		Vector3 to =  -transform.position;
		dir = to.normalized;
		Invoke("Stop", to.magnitude / Speed);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Speed * GameTime.deltaTime.time * dir;
	}

	void Stop() {
		enabled = false;
	}
}
