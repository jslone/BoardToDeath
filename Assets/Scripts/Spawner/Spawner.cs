using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject[] prefabs;
	public bool Wait;
	public bool ScaleOnInstantiate;
	private GameObject last;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject Spawn() {
		return Spawn (Random.Range(0,prefabs.Length));
	}

	public GameObject Spawn(int i) {
		GameObject prefab = prefabs[i];
		if(!(Wait && last)) {
			last = Instantiate(prefab,transform.position,transform.rotation) as GameObject;
			if(ScaleOnInstantiate) {
				Vector3 scale = last.transform.localScale;
				last.transform.parent = transform;
				last.transform.localScale = scale;
			} else {
				last.transform.parent = transform;
			}

			return last;
		}
		return null;
	}
}
