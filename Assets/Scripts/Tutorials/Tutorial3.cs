using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Tutorial3 : Tutorial {
	public Button MenuButton;
	public Button MenuLeftButton;
	public Button MenuRightButton;
	public Souls WorldStatus;
	public Line TSALine;

	GameObject currentMessage;
	List<GameObject> souls = new List<GameObject>();
	int progress = 0;

	// Continue in tutorial
	protected override void ProceedTutorial() {
		Vector3 pos = new Vector3(0, -4f, 0); // position of text message
		switch (phase++) {
			case 0:
				GameTime.paused = true;
				ToggleButton(MenuButton, false);
				CreateMessage(Vector3.zero, "Once you've ferried enough souls, you can use them to purchase upgrades!");
				break;

			case 1:
				pos = new Vector3(5f, 3.25f, 0);
				GameTime.paused = false;
				ToggleButton(MenuButton, true);
				currentMessage = CreateMessage(pos, "Click the Upgrades button to pause the game and view possible upgrades.", -1);
				break;

			// opened menu
			case 2:
				ToggleButton(MenuButton, false);
				Destroy(currentMessage);
				CreateMessage(pos, "Here, you can upgrade Atropos' walking speed, the cut margin of threads, and even buy an upgrade to slow time.");
				break;

			case 3:
				MenuLeftButton.GetComponent<UIUpgradeNav>().Navigate(); // scroll left
				CreateMessage(pos, "In this menu, you can buy and upgrade the speed and capacity of different boats.");
				break;

			case 4:
				MenuRightButton.GetComponent<UIUpgradeNav>().Navigate(); // scroll right twice
				MenuRightButton.GetComponent<UIUpgradeNav>().Navigate();
				CreateMessage(pos, "Finally, you can buy different types of heroes to fight monsters that spawn.");
				break;

			case 5:
				Souls.souls = 10;
				currentMessage = CreateMessage(pos, "Here are 10 souls. Buy a footsoldier with it!", -1);
				break;

			case 6:
				Destroy(currentMessage);
				ToggleButton(MenuButton, true);
				pos = new Vector3(5f, 3.25f, 0);
				currentMessage = CreateMessage(pos, "Click the button to unpause the game and see your new hero.", -1);
				break;

			case 7:
				SpawnSoul(1.5f, 3f);
				SpawnSoul(1.75f, 3f);
				SpawnSoul(2f, 3f);
				if (currentMessage) Destroy(currentMessage);
				ToggleButton(MenuButton, false);
				pos = new Vector3(-3.5f, 3.5f, 0);
				currentMessage = CreateMessage(pos, "Heroes fight off monsters that spawn when souls run out of patience. However, they can get killed too!", 8);
				break;

			case 8:
				SpawnSoul(1f, 5f);
				SpawnSoul(1.5f, 5f);
				SpawnSoul(2f, 5f);
				SpawnSoul(2.5f, 10f);
				SpawnSoul(2.5f, 10f);
				Destroy(currentMessage);
				ToggleButton(MenuButton, true);
				Souls.souls = 50;
				pos = new Vector3(-3.5f, 3.5f, 0);
				currentMessage = CreateMessage(pos, "Buy more powerful heroes to defeat the monsters before they overrun the world, as indicated by the world status meter!", -1);
				break;

			// After all monsters are slain
			case 9:
				Destroy(currentMessage);
				CreateMessage(pos, "Nicely done. Now you're ready to start your job!");
				break;

			// Monster destroyed world
			case 12:
				Destroy(currentMessage);
				WorldStatus.world.Health.x = 1;
				Souls.ClearMonsters();
				CreateMessage(pos, "No, no! The monsters have overrun the world. Try again.");
				break;

			// Reset state after monster rampage
			case 13:
				phase = 8;
				foreach (GameObject soul in souls) {
					if (soul) {
						Destroy(soul);
					}
				}
				souls.Clear();
				WorldStatus.world.Health.x = 500;
				Souls.souls = 50;
				ProceedTutorial();
				break;

			default:
				CompleteTutorial(3);
				break;
		}
	}

	void Update() {
		// Waiting for monsters to die
		if (phase == 9 && Souls.monsters == 0 && TSALine.Length == 0) {
			ProceedTutorial();
		}
	}

	public override void UpdateProgress(int value) {
		if (value < 0) {
			// Monster destroyed world
			phase = 12;
			ProceedTutorial();
		} else if (value == 0 && (phase == 2 || phase == 7)) {
			// opened or closed menu
			ProceedTutorial();
		} else if (value == 1 && phase == 6) {
			// purchased hero
			ProceedTutorial();
		}
	}

	void ToggleButton(Button button, bool on) {
		button.interactable = on;
		EventTrigger trigger = button.GetComponent<EventTrigger>();
		if (trigger) {
			trigger.enabled = on;
		}
	}

	GameObject SpawnSoul(float patience, float attack) {
		GameObject soul = SoulSpawner.UseSpawner();
		Patience sp = soul.GetComponent<Patience>();
		if (patience > 0) {
			sp.TTL = patience;
			sp.enabled = true;
		}
		RPGCharacter monster = soul.GetComponent<RPGCharacter>();
		monster.Attack = new Vector2(attack, attack);
		souls.Add(soul);
		return soul;
	}
}
