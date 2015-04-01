using UnityEngine;
using System.Collections;

public class RandomSpawner : RandomEvent {
	public Spawner spawner;

	protected override void Event () {
		spawner.Spawn();
	}
}
