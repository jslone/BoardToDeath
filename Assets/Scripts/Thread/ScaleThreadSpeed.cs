using UnityEngine;
using System.Collections;

public class ScaleThreadSpeed : MonoBehaviour {
	public TimedEquations scale;
	GameObject[] prefabs;

	// Use this for initialization
	void Start () {
		prefabs = GetComponent<Spawner>().prefabs;
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject prefab in prefabs) {
			prefab.GetComponent<Logistic>().Height = scale.value;
		}
	}

}
