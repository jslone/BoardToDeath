using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject prefab;
	public bool Wait;
	private GameObject last;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject Spawn() {
		if(!(Wait && last)) {
			last = Instantiate(prefab,transform.position,transform.rotation) as GameObject;
			last.transform.parent = transform;

			return last;
		}
		return null;
	}
}
