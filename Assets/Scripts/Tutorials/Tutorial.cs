using UnityEngine;
using System.Collections;

public abstract class Tutorial : MonoBehaviour {
	public static Tutorial CurrentTutorial;
	public GameObject Message;
	protected int phase = 0;

	public static void Proceed() {
		CurrentTutorial.ProceedTutorial();
	}

	// Use this for initialization
	void Start () {
		CurrentTutorial = this; // there should only be one tutorial per scene
		ProceedTutorial();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateProgress() {
		UpdateProgress(1);
	}
	public abstract void UpdateProgress(int count);
	protected abstract void ProceedTutorial();

	IEnumerator WaitForSecondsAndProceed(float t) {
		yield return new WaitForSeconds(t);
		ProceedTutorial();
	}

	protected void WaitAndProceed(float t) {
		StartCoroutine(WaitForSecondsAndProceed(t));
	}

	protected void CompleteTutorial(int level) {
		if (PlayerPrefs.GetInt("levelUnlocked", 0) < level) {
			PlayerPrefs.SetInt("levelUnlocked", level);
		}
		CurrentTutorial = null;
		Application.LoadLevel("title");
	}

	// Create text message
	protected GameObject CreateMessage(Vector3 pos, string text, float duration) {
		GameObject message = Instantiate(Message, pos, Quaternion.identity) as GameObject;
		message.transform.parent = transform;
		message.GetComponent<UIMessage>().MessageText = text;
		message.GetComponent<UIMessage>().Duration = duration;
		message.GetComponent<UIMessage>().ProceedTutorialOnClose = (duration >= 0);
		return message;
	}

	protected GameObject CreateMessage(Vector3 pos, string text) {
		return CreateMessage(pos, text, 0);
	}

}
