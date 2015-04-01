using UnityEngine;
using System.Collections;

public class Thread : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Cut() {
		// Spawn soul
		SoulSpawner.UseSpawner();
		// Break thread
		Destroy(gameObject);
	}
}
