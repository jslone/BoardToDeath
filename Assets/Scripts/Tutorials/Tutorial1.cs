using UnityEngine;
using System.Collections;

public class Tutorial1 : Tutorial {
	public GameObject Thread;
	public GameObject Atropos;
	GameObject currentMessage;

	// Continue in tutorial
	public override void ProceedTutorial() {
		Vector3 pos = new Vector3(-5f, 2.75f, 0); // position of text message
		switch (phase++) {
			case 0:
				GameTime.paused = true;
				CreateMessage(pos, "Hades! It's good to see you back. The souls are getting a bit restless up on Earth and I need you to deal with 'em.");
				break;

			case 1:
				WaitAndProceed(2f);
				break;

			case 2:
				CreateMessage(pos, "...Don't tell me you've forgotten how to manage souls in your short vacation! Oh, all right, I'll give you a refresher.");
				break;

			case 3:
				pos.x = -4.5f;
				// TODO: add animated pointer in addition to highlighting thread
				Thread.GetComponentInChildren<UISelectable>().Highlight(true);
				CreateMessage(pos, "This is a thread of life. It represents a human life in the world of living.");
				break;

			case 4:
				pos.x = 5.5f;
				Thread.GetComponentInChildren<UISelectable>().Highlight(false);
				Atropos.GetComponent<UISelectable>().Highlight(true);
				Atropos.GetComponent<MoveCharacter>().Flip();
				CreateMessage(pos, "This is Atropos. She is one of the three Fates that cuts the threads of life.");
				break;

			case 5:
				Atropos.GetComponent<UISelectable>().Highlight(false);
				Atropos.GetComponent<UISelectable>().enabled = false;
				Atropos.GetComponent<MoveCharacter>().Flip();
				currentMessage = CreateMessage(pos, "Click on a thread to cut and end a human's life.", -1);
				GameTime.paused = false;
				break;

			// TODO: on cut
			case 6:
				GameTime.paused = true;
				Destroy(currentMessage);
				currentMessage = CreateMessage(pos, "good work m8 you win the tutorial");
				break;

			default:
				break;
		}
	}

}
