using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Tutorial3 : Tutorial {
	public Button MenuButton;
	public List<GameObject> Threads;
	public List<GameObject> BoardingLines;

	GameObject currentMessage;
	int progress = 0;

	// Continue in tutorial
	protected override void ProceedTutorial() {
		Vector3 pos = new Vector3(4f, 2.75f, 0); // position of text message
		switch (phase++) {
			case 0:
				GameTime.paused = true;
				CreateMessage(pos, "Unfortunately, due to budget cuts, we can only afford to give you one boat.");
				break;

			case 1:
				CreateMessage(pos, "However, once you've ferried enough souls, you can use them to purchase upgrades!");
				break;

			case 2:
				pos = new Vector3(5f, 3.25f, 0);
				GameTime.paused = false;
				currentMessage = CreateMessage(pos, "Click the Menu button to pause the game and view possible upgrades.", -1);
				break;

			// opened menu
			case 3:
				Destroy(currentMessage);
				currentMessage = CreateMessage(pos, "Click to purchase a new ship.", -1);
				break;

			default:
				CompleteTutorial(3);
				break;
		}
	}

	public override void UpdateProgress(int value) {
		// opened menu
		if (value == 0 && phase == 3) {
			ProceedTutorial();
		}
	}

	void ToggleInteraction(bool on) {
		foreach (GameObject thread in Threads) {
			thread.GetComponent<BoxCollider2D>().enabled = on;
		}
		foreach (GameObject line in BoardingLines) {
			line.GetComponent<BoxCollider2D>().enabled = on;
		}
		MenuButton.interactable = on;
	}
}
