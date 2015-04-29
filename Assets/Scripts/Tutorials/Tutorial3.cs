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
	public Souls WorldStatus;

	GameObject currentMessage;
	List<GameObject> souls = new List<GameObject>();
	int progress = 0;

	// Continue in tutorial
	protected override void ProceedTutorial() {
		Vector3 pos = new Vector3(0, -3f, 0); // position of text message
		switch (phase++) {
			case 0:
				GameTime.paused = true;
				ToggleInteraction(false);
				pos = new Vector3(4f, 2.75f, 0);
				CreateMessage(pos, "Once you've ferried enough souls, you can use them to purchase upgrades!");
				break;

			case 1:
				pos = new Vector3(5f, 3.25f, 0);
				GameTime.paused = false;
				ToggleButton(MenuButton, true);
				currentMessage = CreateMessage(pos, "Click the Menu button to pause the game and view possible upgrades.", -1);
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
				currentMessage = CreateMessage(pos, "Click on Menu to unpause the game and see your new hero.", -1);
				break;

			case 7:
				SpawnSoul(2f, 3f);
				SpawnSoul(1.5f, 3f);
				if (currentMessage) Destroy(currentMessage);
				ToggleButton(MenuButton, false);
				pos = new Vector3(4f, 2.75f, 0);
				currentMessage = CreateMessage(pos, "Heroes fight off monsters that spawn when souls run out of patience. However, they can get killed too!", 10);
				break;

			case 8:
				souls.Add(SpawnSoul(1f, 5f));
				souls.Add(SpawnSoul(1.5f, 5f));
				souls.Add(SpawnSoul(2f, 5f));
				souls.Add(SpawnSoul(2.5f, 5f));
				souls.Add(SpawnSoul(2.5f, 5f));
				Destroy(currentMessage);
				ToggleButton(MenuButton, true);
				Souls.souls = 50;
				currentMessage = CreateMessage(pos, "Buy more powerful heroes to defeat the monsters before they overrun the world!", -1);
				break;

			// After all monsters are slain
			case 9:
				Destroy(currentMessage);
				CreateMessage(pos, "Nicely done. Now you're ready to start your job!");
				break;

			// Monster destroyed world
			case 10:
				Destroy(currentMessage);
				WorldStatus.world.Health.x = 500;
				Souls.ClearMonsters();
				WorldStatus.enabled = false;
				CreateMessage(pos, "No, no! The monsters have overrun the world. Try again.");
				break;

			// Reset state after monster rampage
			case 11:
				phase = 8;
				progress = 2;
				foreach (GameObject soul in souls) {
					if (soul) {
						Destroy(soul);
					}
				}
				souls.Clear();
				WorldStatus.enabled = true;
				Souls.ClearMonsters();
				Souls.souls = 50;
				ProceedTutorial();
				break;

			default:
				CompleteTutorial(3);
				break;
		}
	}

	public override void UpdateProgress(int value) {
		if (value < 0) {
			// Monster destroyed world
			phase = 10;
			ProceedTutorial();
		} else if (value == 0 && (phase == 2 || phase == 7)) {
			// opened or closed menu
			ProceedTutorial();
		} else if (value == 1 && phase == 6) {
			// purchased boat
			ProceedTutorial();
		} else if (value == 1 && phase == 9) {
			// hero killed off monster
			if (++progress == 7) {
				ProceedTutorial();
			}
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

	GameObject SpawnSoul(float patience, float attack) {
		GameObject soul = SoulSpawner.UseSpawner();
		Patience sp = soul.GetComponent<Patience>();
		if (patience > 0) {
			sp.TTL = patience;
			sp.enabled = true;
		}
		RPGCharacter monster = soul.GetComponent<RPGCharacter>();
		monster.Attack = new Vector2(attack, attack);
		return soul;
	}
}
