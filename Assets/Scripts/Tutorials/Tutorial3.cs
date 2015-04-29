using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Tutorial3 : Tutorial {
	public List<GameObject> Threads;
	public List<GameObject> BoardingLines;
	public Button MenuButton;
	public Button MenuLeftButton;
	public Button MenuRightButton;

	GameObject currentMessage;
	int progress = 0;

	// Continue in tutorial
	protected override void ProceedTutorial() {
		Vector3 pos = new Vector3(0, -3f, 0); // position of text message
		switch (phase++) {
			case 0:
				GameTime.paused = true;
				ToggleInteraction(false);
				pos = new Vector3(4f, 2.75f, 0);
				CreateMessage(pos, "Unfortunately, due to budget cuts, we can only afford to give you one boat.");
				break;

			case 1:
				pos = new Vector3(4f, 2.75f, 0);
				CreateMessage(pos, "However, once you've ferried enough souls, you can use them to purchase upgrades!");
				break;

			case 2:
				pos = new Vector3(5f, 3.25f, 0);
				GameTime.paused = false;
				ToggleButton(MenuButton, true);
				currentMessage = CreateMessage(pos, "Click the Menu button to pause the game and view possible upgrades.", -1);
				break;

			// opened menu
			case 3:
				ToggleButton(MenuButton, false);
				Destroy(currentMessage);
				CreateMessage(pos, "Here, you can upgrade Atropos' walking speed, the cut margin of threads, and even buy an upgrade to slow time.");
				break;

			case 4:
				MenuLeftButton.GetComponent<UIUpgradeNav>().Navigate(); // scroll left
				CreateMessage(pos, "In this menu, you can buy and upgrade the speed and capacity of different boats.");
				break;

			case 5:
				Souls.souls = 15;
				currentMessage = CreateMessage(pos, "Here are 15 souls. Purchase a speed boat with it!", -1);
				break;

			case 6:
				Destroy(currentMessage);
				ToggleButton(MenuButton, true);
				pos = new Vector3(5f, 3.25f, 0);
				currentMessage = CreateMessage(pos, "Click on Menu to unpause the game and see your new ship.", -1);
				break;

			case 7:
				Destroy(currentMessage);
				break;

			default:
				CompleteTutorial(3);
				break;
		}
	}

	public override void UpdateProgress(int value) {
		if (value == 0 && (phase == 3 || phase == 7)) {
			// opened or closed menu
			ProceedTutorial();
		} else if (value == 1 && phase == 6) {
			// purchased boat
			ProceedTutorial();
		}
	}

	void ToggleInteraction(bool on) {
		foreach (GameObject thread in Threads) {
			thread.GetComponent<BoxCollider2D>().enabled = on;
			thread.GetComponent<RandomSpawner>().enabled = on;
		}
		foreach (GameObject line in BoardingLines) {
			line.GetComponent<BoxCollider2D>().enabled = on;
		}
		ToggleButton(MenuButton, on);
		ToggleButton(MenuLeftButton, on);
		ToggleButton(MenuRightButton, on);
	}

	void ToggleButton(Button button, bool on) {
		button.interactable = on;
		EventTrigger trigger = button.GetComponent<EventTrigger>();
		if (trigger) {
			trigger.enabled = on;
		}
	}
}
