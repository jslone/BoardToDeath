using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIMenu : MonoBehaviour {
	public GameObject menu;
	public GameObject otherMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Toggle() {
		if (otherMenu.activeSelf) {
			menu.SetActive(true);
			otherMenu.SetActive(false);
		} else {
			menu.SetActive(!menu.activeSelf);
			GameTime.paused = !GameTime.paused;
		}
	}
}
