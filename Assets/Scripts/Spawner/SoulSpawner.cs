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

	private void UseSpawnerLocal() {
		GameObject soul = Spawn();
		if(soul) {
			line.Add(soul.GetComponent<CharacterLine>());
		}
	}

	public static void UseSpawner() {
		if(_instance) {
			_instance.UseSpawnerLocal();
		}
	}
}
