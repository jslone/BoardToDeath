using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tutorial2 : Tutorial {
	public GameObject BoardingLine1;
	public GameObject BoardingLine2;
	public GameObject BoardingLine3;
	public Souls WorldStatus;

	GameObject currentMessage;
	List<GameObject> souls = new List<GameObject>();
	int progressedSouls = 0;

	// Continue in tutorial
	protected override void ProceedTutorial() {
		Vector3 pos = new Vector3(-5f, 2.75f, 0); // position of text message
		switch (phase++) {
			case 0:
				GameTime.paused = true;
				CreateMessage(pos, "After a human has perished, you must ferry its soul across the River Styx.");
				break;

			case 1:
				GameTime.paused = false;
				SpawnSoul(0, 0);
				pos = new Vector3(-4f, -4.25f, 0);
				ToggleBoardingLines(true);
				currentMessage = CreateMessage(pos, "Click on a dock to move a soul to that line.", -1);
				break;

			case 2:
				Destroy(currentMessage);
				pos = new Vector3(0, 0, 0);
				currentMessage = CreateMessage(pos, "Wait for the ship to ferry your soul across the river.", -1);
				break;

			case 3:
				GameTime.paused = true;
				Destroy(currentMessage);
				pos = new Vector3(0, 0, 0);
				CreateMessage(pos, "Different boats have different capacities and speeds.");
				break;

			case 4:
				souls.Add(SpawnSoul(2f, 0));
				pos.x = -4f;
				ToggleBoardingLines(false);
				CreateMessage(pos, "Each soul has a patience meter. If its patience depletes, the soul will transform into a monster!", 6);
				GameTime.paused = false;
				break;

			case 5:
				ToggleBoardingLines(true);
				pos.x = -4f;
				currentMessage = CreateMessage(pos, "Ferry the remaining souls across before they run out of patience!", -1);
				for (int i = 0; i < 10; i++) {
					souls.Add(SpawnSoul(Random.Range(20f, 30f), 100f));
				}
				break;

			// After ferrying all 12 souls
			case 6:
				GameTime.paused = true;
				Destroy(currentMessage);
				CreateMessage(pos, "Good work, Hades.");
				break;

			// Monster destroyed world
			case 10:
				Destroy(currentMessage);
				WorldStatus.world.Health.x = 1;
				Souls.ClearMonsters();
				WorldStatus.enabled = false;
				ToggleBoardingLines(false);
				CreateMessage(pos, "No, no! The monsters have overrun the world. Try again!");
				break;

			// Reset state after monster rampage
			case 11:
				phase = 5;
				progressedSouls = 2;
				foreach (GameObject soul in souls) {
					if (soul) {
						Destroy(soul);
					}
				}
				souls.Clear();
				WorldStatus.enabled = true;
				Souls.ClearMonsters();
				ProceedTutorial();
				break;

			default:
				CompleteTutorial(2);
				break;
		}
	}

	public override void UpdateProgress(int count) {
		if (count < 0) {
			// Monster destroyed world
			phase = 10;
			ProceedTutorial();
		} else {
			// Successfully queued or shipped soul
			progressedSouls += count;
			if (progressedSouls <= 2 || progressedSouls >= 22) { // loaded 11 boats total
				ProceedTutorial();
			}
		}
		
	}

	void ToggleBoardingLines(bool on) {
		BoardingLine1.GetComponent<BoxCollider2D>().enabled = on;
		BoardingLine2.GetComponent<BoxCollider2D>().enabled = on;
		BoardingLine3.GetComponent<BoxCollider2D>().enabled = on;
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
