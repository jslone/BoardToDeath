using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialBoat : Boat {

	protected override void UnloadBoat() {
		if (onBoat.Count > 0) {
			Tutorial.CurrentTutorial.UpdateProgress(onBoat.Count);
		}
		base.UnloadBoat();
	}
}
