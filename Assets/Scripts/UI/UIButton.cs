using UnityEngine;
using System.Collections;

public enum ButtonAction {
	PLAY,
	TUTORIAL,
	QUIT
}

public class UIButton : MonoBehaviour {
	public ButtonAction action;
	
	public void OnClick() {
		switch(action) {
			case ButtonAction.PLAY:
				Application.LoadLevel("game");	// game scene
				break;
			case ButtonAction.TUTORIAL:
				Application.LoadLevel("tutorial1");	// title scene
				break;
/* 			case ButtonAction.CREDITS:
				Application.LoadLevel("credits");	// credits scene
				break; 
*/
			case ButtonAction.QUIT:
				Application.Quit();
				break;
		}
	}
}
