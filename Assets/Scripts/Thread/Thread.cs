using UnityEngine;
using System.Collections;

public class Thread : MonoBehaviour {
	public TimedEquations patience;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Cut() {
		// Spawn soul
		GameObject soul = SoulSpawner.UseSpawner();

		// Set souls patience
		if(soul) {
			soul.GetComponent<Patience>().TimeWillWait = patience.value;
			Debug.Log(patience.value);
		}

		// Break thread
		Destroy(gameObject);
	}
}
