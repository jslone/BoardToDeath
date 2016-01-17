using UnityEngine;
using UnityEngine.SceneManagement;
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

	protected void WaitAndProceed(float t) {
		Invoke("ProceedTutorial", t);
	}

	protected void CompleteTutorial(int level) {
		if (PlayerPrefs.GetInt("levelUnlocked", 0) < level) {
			PlayerPrefs.SetInt("levelUnlocked", level);
		}
		CurrentTutorial = null;
		string levelToLoad;
		switch (level) {
			case 1:
				levelToLoad = "tutorial2";
				break;
			case 2:
				levelToLoad = "tutorial3";
				break;
			default:
				levelToLoad = "title";
				break;
		}
		SceneManager.LoadScene(levelToLoad);
	}

	// Create text message
	protected GameObject CreateMessage(Vector3 pos, string text, float duration) {
		GameObject message = Instantiate(Message, pos, Quaternion.identity) as GameObject;
		message.transform.SetParent(transform);
		message.GetComponent<UIMessage>().MessageText = text;
		message.GetComponent<UIMessage>().Duration = duration;
		message.GetComponent<UIMessage>().ProceedTutorialOnClose = (duration >= 0);
		return message;
	}

	protected GameObject CreateMessage(Vector3 pos, string text) {
		return CreateMessage(pos, text, 0);
	}

}
