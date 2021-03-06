﻿using UnityEngine;
using System.Collections;

public class TutorialThread : Thread {

	void Update () {
		spriteRenderer.color = Color.Lerp(goodColor, badColor, 2.5f * patience.position - 1.25f);
	}

	public override void Cut() {
		// Spawn soul
		GameObject soul = SoulSpawner.UseSpawner();
		Tutorial.CurrentTutorial.UpdateProgress();

		// Set souls patience
		if(soul) {
			Patience sp = soul.GetComponent<Patience>();
			sp.TTL *= patience.value;
			//sp.enabled = true;
		}

		// Break thread
		Destroy(gameObject);
	}
}
