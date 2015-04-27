using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UILockDifficulty : MonoBehaviour {
	public Button button;
	public int difficulty;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("levelUnlocked", 0) < difficulty) {
			button.interactable = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
