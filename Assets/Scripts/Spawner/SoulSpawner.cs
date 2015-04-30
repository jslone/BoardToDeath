using UnityEngine;
using System.Collections;

public class SoulSpawner : Spawner {
	public Line line;
	private static SoulSpawner _instance;

	// Use this for initialization
	void Start () {
		if(_instance) {
			Debug.LogError("Can't have multiple instances of SingletonSpawner: " + _instance.ToString() + "," + this.ToString());
		}
		_instance = this;
	}

	private GameObject UseSpawnerLocal() {
		GameObject soul = Spawn();
		if(soul) {
			line.Add(soul.GetComponent<CharacterLine>());
		}
		return soul;
	}
	
	public static GameObject UseSpawner() {
		if(_instance) {
			return _instance.UseSpawnerLocal();
		}
		return null;
	}

	private GameObject UseSpawnerLocal(int i) {
		GameObject soul = Spawn(i);
		if(soul) {
			line.Add(soul.GetComponent<CharacterLine>());
		}
		return soul;
	}

	public static GameObject UseSpawner(int i) {
		if(_instance) {
			return _instance.UseSpawnerLocal(i);
		}
		return null;
	}
}
