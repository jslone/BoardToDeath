using UnityEngine;
using System.Collections;

public class Tutorial1 : Tutorial {
	public GameObject Thread1;
	public GameObject Thread2;
	public GameObject Thread3;
	public GameObject Atropos;

	GameObject currentMessage;
	int cutThreads = 0;

	// Continue in tutorial
	protected override void ProceedTutorial() {
		Vector3 pos = new Vector3(-5f, 2.75f, 0); // position of text message
		switch (phase++) {
			case 0:
				GameTime.paused = true;
				CreateMessage(Vector3.zero, "Agnetha... Fields of Asphodel.");
				break;

			case 1:
				CreateMessage(Vector3.zero, "Sisyphus... Fields of Punishment.");
				break;

			case 2:
				WaitAndProceed(1f);
				break;

			case 3:
				CreateMessage(Vector3.zero, "NEXT. Step up, mortal, don't be afraid. Your name?");
				break;

			case 4:
				WaitAndProceed(1f);
				break;

			case 5:
				CreateMessage(Vector3.zero, "Hmm... that's odd. I can't seem to find your name on the list. Are you sure you're dead?");
				break;

			case 6:
				CreateMessage(Vector3.zero, "Oh! My apologies, you must be the new intern. Let me show you around.");
				break;

			case 7:
				// TODO: add animated pointer in addition to highlighting thread
				Thread1.GetComponent<UISelectable>().Highlight(true);
				CreateMessage(pos, "This is a thread of life. It represents a human life in the world of living.");
				break;

			case 8:
				pos.x = 5.75f;
				Thread1.GetComponent<UISelectable>().Highlight(false);
				Atropos.GetComponent<UISelectable>().Highlight(true);
				Atropos.GetComponent<Fate>().Flip();
				CreateMessage(pos, "This is Atropos. She is one of the three Fates that cuts the threads of life.");
				break;

			case 9:
				Atropos.GetComponent<UISelectable>().Highlight(false);
				Atropos.GetComponent<UISelectable>().enabled = false;
				Atropos.GetComponent<Fate>().Flip();
				GameTime.paused = false;
				Thread1.GetComponent<Spawner>().Spawn();
				WaitAndProceed(2f);
				break;

			case 10:
				GameTime.paused = true;
				Thread1.GetComponent<UISelectable>().Highlight(true);
				CreateMessage(pos, "See the tear in the thread? Cutting threads when Atropos' scissors line up with the optimal point results in happier souls.");
				break;

			case 11:
				Thread1.GetComponent<UISelectable>().Highlight(false);
				EnableThread(Thread1);
				EnableThread(Thread2);
				EnableThread(Thread3);
				currentMessage = CreateMessage(pos, "Click on a thread to cut and end a human's life. Try to line up the scissors with the optimal point!", -1);
				GameTime.paused = false;
				break;

			// On first cut
			case 12:
				pos = new Vector3(3f, 0, 0);
				GameTime.paused = true;
				Destroy(currentMessage);
				CreateMessage(pos, "That's it! Cutting a thread spawns a soul. The closer to the optimal position, the greater the soul's patience.");
				break;

			case 13:
				currentMessage = CreateMessage(pos, "Let's send a few more souls to the underworld. You know, just for practice!", -1);
				GameTime.paused = false;
				break;

			// On final cut
			case 14:
				GameTime.paused = true;
				Destroy(currentMessage);
				CreateMessage(pos, "Well done. I hope you're enjoying yourself! Let's move on.");
				break;

			default:
				CompleteTutorial(1);
				break;
		}
	}

	// Successfully cut thread
	public override void UpdateProgress(int count) {
		cutThreads += count;
		if (cutThreads == 1 || cutThreads == 7) {
			ProceedTutorial();
		}
	}

	void EnableThread(GameObject thread) {
		thread.GetComponent<RandomSpawner>().enabled = true;
		thread.GetComponent<BoxCollider2D>().enabled = true;
	}

}
