using UnityEngine;
using System.Collections;

public class TutorialThread : Thread {

	public override void Cut() {
		// Spawn soul
		GameObject soul = SoulSpawner.UseSpawner();
		Tutorial.CurrentTutorial.UpdateProgress();

		// Break thread
		Destroy(gameObject);
	}
}
