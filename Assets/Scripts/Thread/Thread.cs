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

	public virtual void Cut() {
		// Spawn soul
		GameObject soul = SoulSpawner.UseSpawner();

		// Set souls patience
		if(soul) {
			Patience sp = soul.GetComponent<Patience>();
			sp.TTL *= patience.value;
			sp.enabled = true;
		}

		// Break thread
		Destroy(gameObject);
	}
}
