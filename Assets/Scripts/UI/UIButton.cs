using UnityEngine;
using System.Collections;

public enum ButtonAction {
	PLAY,
	TUTORIAL1,
	TUTORIAL2,
	TUTORIAL3,
	QUIT
}

public class UIButton : MonoBehaviour {
	public ButtonAction action;
	
	public void OnClick() {
		switch(action) {
			case ButtonAction.PLAY:
				Application.LoadLevel("game");	// game scene
				break;
			case ButtonAction.TUTORIAL1:
				Application.LoadLevel("tutorial1");	// thread cutting tutorial
				break;
			case ButtonAction.TUTORIAL2:
				Application.LoadLevel("tutorial2");	// boat tutorial
				break;
			case ButtonAction.TUTORIAL3:
				Application.LoadLevel("tutorial2");	// menu tutorial
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
