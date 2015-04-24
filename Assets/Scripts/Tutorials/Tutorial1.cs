using UnityEngine;
using System.Collections;

public class Tutorial1 : Tutorial {
	public GameObject Thread1;
	public GameObject Thread2;
	public GameObject Thread3;
	public GameObject Atropos;
	public SoulSpawner Spawner;

	GameObject currentMessage;
	int cutThreads = 0;

	// Continue in tutorial
	protected override void ProceedTutorial() {
		Vector3 pos = new Vector3(-5f, 2.75f, 0); // position of text message
		switch (phase++) {
			case 0:
				GameTime.paused = true;
				CreateMessage(pos, "Hades! It's good to see you back. The souls are getting a bit restless up on Earth and I need you to deal with 'em.");
				break;

			case 1:
				WaitAndProceed(1.5f);
				break;

			case 2:
				CreateMessage(pos, "...Don't tell me you've forgotten how to manage souls in your short vacation! Oh, all right, I'll give you a refresher.");
				break;

			case 3:
				pos.x = -4.5f;
				// TODO: add animated pointer in addition to highlighting thread
				Thread1.GetComponent<UISelectable>().Highlight(true);
				CreateMessage(pos, "This is a thread of life. It represents a human life in the world of living.");
				break;

			case 4:
				pos.x = 5.5f;
				Thread1.GetComponent<UISelectable>().Highlight(false);
				Atropos.GetComponent<UISelectable>().Highlight(true);
				Atropos.GetComponent<Fate>().Flip();
				CreateMessage(pos, "This is Atropos. She is one of the three Fates that cuts the threads of life.");
				break;

			case 5:
				Atropos.GetComponent<UISelectable>().Highlight(false);
				Atropos.GetComponent<UISelectable>().enabled = false;
				Atropos.GetComponent<Fate>().Flip();
				GameTime.paused = false;
				Thread1.GetComponent<Spawner>().Spawn();
				WaitAndProceed(2f);
				break;

			case 6:
				pos.x = -4.5f;
				GameTime.paused = true;
				Thread1.GetComponent<UISelectable>().Highlight(true);
				CreateMessage(pos, "See the tear in the thread? Cutting threads when Atropos' scissors line up with the optimal point results in happier souls.");
				break;

			case 7:
				Thread1.GetComponent<UISelectable>().Highlight(false);
				EnableThread(Thread1);
				EnableThread(Thread2);
				EnableThread(Thread3);
				currentMessage = CreateMessage(pos, "Click on a thread to cut and end a human's life. Try to line up the scissors with the optimal point!", -1);
				GameTime.paused = false;
				break;

			// On first cut
			case 8:
				pos = new Vector3(4.5f, 0, 0);
				GameTime.paused = true;
				Destroy(currentMessage);
				CreateMessage(pos, "That's it! Cutting a thread spawns a soul. The closer to the optimal position, the greater the soul's patience.");
				break;

			case 9:
				currentMessage = CreateMessage(pos, "Let's send a few more souls to the underworld. You know, just for practice!", -1);
				GameTime.paused = false;
				break;

			// On final cut
			case 10:
				GameTime.paused = true;
				Destroy(currentMessage);
				currentMessage = CreateMessage(pos, "Well done, Hades. I hope you're enjoying yourself! Let's move on.");
				break;

			default:
				CompleteTutorial(1);
				break;
		}
	}

	// Successfully cut thread
	public override void UpdateProgress() {
		switch (++cutThreads) {
			case 1:
			case 7:
				ProceedTutorial();
				break;
		}
	}

	void EnableThread(GameObject thread) {
		thread.GetComponent<RandomSpawner>().enabled = true;
		thread.GetComponent<BoxCollider2D>().enabled = true;
	}

}
