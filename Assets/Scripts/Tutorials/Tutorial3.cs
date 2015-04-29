using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
				ToggleInteraction(false);
				CreateMessage(pos, "Unfortunately, due to budget cuts, we can only afford to give you one boat.");
				break;

			case 1:
				CreateMessage(pos, "However, once you've ferried enough souls, you can use them to purchase upgrades!");
				break;

			case 2:
				pos = new Vector3(5f, 3.25f, 0);
				GameTime.paused = false;
				ToggleMenuButton(true);
				currentMessage = CreateMessage(pos, "Click the Menu button to pause the game and view possible upgrades.", -1);
				break;

			// opened menu
			case 3:
				pos = new Vector3(0f, -3f, 0);
				ToggleMenuButton(false);
				Destroy(currentMessage);
				CreateMessage(pos, "Here, you can upgrade Atropos' walking speed, the cut window of threads, and even buy an upgrade to slow time.");
				break;

			case 4:
				pos = new Vector3(0f, -3f, 0);
				// TODO: scroll left
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
		ToggleMenuButton(on);
	}

	void ToggleMenuButton(bool on) {
		MenuButton.interactable = on;
		MenuButton.GetComponent<EventTrigger>().enabled = on;
	}
}
