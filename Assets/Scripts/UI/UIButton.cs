using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum ButtonAction {
	PLAY,
	TUTORIAL1,
	TUTORIAL2,
	TUTORIAL3,
	MENU,
	QUIT
}

public class UIButton : MonoBehaviour {
	public ButtonAction action;
	
	public void OnClick() {
		switch(action) {
			case ButtonAction.PLAY:
				int lvl = PlayerPrefs.GetInt("levelUnlocked");
				if(lvl >= 3) {
					SceneManager.LoadScene("game");	// game scene
				} else {
					SceneManager.LoadScene("tutorial" + (lvl+1));
				}
				break;
			case ButtonAction.TUTORIAL1:
				SceneManager.LoadScene("tutorial1");	// thread cutting tutorial
				break;
			case ButtonAction.TUTORIAL2:
				SceneManager.LoadScene("tutorial2");	// boat tutorial
				break;
			case ButtonAction.TUTORIAL3:
				SceneManager.LoadScene("tutorial3");	// menu tutorial
				break;
			case ButtonAction.MENU:
				SceneManager.LoadScene("title");	// load menu
				break;
			case ButtonAction.QUIT:
				Application.Quit();
				break;
		}
	}
}
