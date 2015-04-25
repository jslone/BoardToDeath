using UnityEngine;
using System.Collections;

public class Tutorial2 : Tutorial {
	public GameObject BoardingLine1;
	public GameObject BoardingLine2;
	public GameObject BoardingLine3;

	GameObject currentMessage;
	int queuedSouls = 0;

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
				SoulSpawner.UseSpawner();
				pos = new Vector3(-4f, -4.25f, 0);
				BoardingLine1.GetComponent<BoxCollider2D>().enabled = true;
				BoardingLine2.GetComponent<BoxCollider2D>().enabled = true;
				BoardingLine3.GetComponent<BoxCollider2D>().enabled = true;
				currentMessage = CreateMessage(pos, "Click on a dock to move a soul to that line.", -1);
				break;

			case 2:
				Destroy(currentMessage);
				pos = new Vector3(0, 0, 0);
				currentMessage = CreateMessage(pos, "Next, click on the ship to ferry your soul across the river.", -1);
				break;

			case 3:
				GameTime.paused = true;
				Destroy(currentMessage);
				pos = new Vector3(0, 0, 0);
				CreateMessage(pos, "Different boats have different capacities and speeds.");
				break;

			case 4:
				SoulSpawner.UseSpawner();
				pos.x = -4f;
				// TODO: show soul turning into monster?
				CreateMessage(pos, "Each soul has a patience meter. Make sure that the souls are loaded onto the boats before they run out of patience!");
				break;

			case 5:
				GameTime.paused = false;
				pos.x = -4f;
				currentMessage = CreateMessage(pos, "Ferry the remaining souls across before they run out of patience!", -1);
				for (int i = 0; i < 10; i++) {
					SoulSpawner.UseSpawner();
				}
				break;

			// After ferrying all 12 souls
			case 6:
				GameTime.paused = true;
				Destroy(currentMessage);
				CreateMessage(pos, "Good work, Hades.");
				break;

			default:
				CompleteTutorial(2);
				break;
		}
	}

	// Successfully queued or shipped soul
	public override void UpdateProgress(int count) {
		queuedSouls += count;
		Debug.Log(queuedSouls);
		if (queuedSouls <= 2 || queuedSouls >= 24) { // loaded 12 boats total
			ProceedTutorial();
		}
	}


}
