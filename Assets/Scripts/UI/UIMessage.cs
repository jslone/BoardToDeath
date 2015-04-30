using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMessage : MonoBehaviour {
	public Text Message;
	public GameObject ContinueText;
	public string MessageText
	{
		get { return Message.text; }
		set { Message.text = value; }
	}
	public bool ProceedTutorialOnClose = false;

	/** How long message will last before fading.
	 *  0 = player must click to continue
	 * -1 = lasts forever; creator is responsible for destroying object
	 */
	public float Duration = 0;

	// Use this for initialization
	void Start () {
		if (Duration == 0) {
			ContinueText.SetActive(true);
		} else if (Duration > 0) {
			Invoke("OnCloseMessage", Duration);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void CloseMessage() {
		if (Duration == 0) {
			OnCloseMessage();
		}
	}

	void OnCloseMessage() {
		Destroy(gameObject); // TODO: fade before killing message
		if (ProceedTutorialOnClose) {
			Debug.Log(ProceedTutorialOnClose);
			Tutorial.Proceed();
		}
	}
}
