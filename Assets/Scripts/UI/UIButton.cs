using UnityEngine;
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
					Application.LoadLevel("game");	// game scene
				} else {
					Application.LoadLevel("tutorial" + (lvl+1));
				}
				break;
			case ButtonAction.TUTORIAL1:
				Application.LoadLevel("tutorial1");	// thread cutting tutorial
				break;
			case ButtonAction.TUTORIAL2:
				Application.LoadLevel("tutorial2");	// boat tutorial
				break;
			case ButtonAction.TUTORIAL3:
				Application.LoadLevel("tutorial3");	// menu tutorial
				break;
			case ButtonAction.MENU:
				Application.LoadLevel("title");	// load menu
				break;
			case ButtonAction.QUIT:
				Application.Quit();
				break;
		}
	}
}
