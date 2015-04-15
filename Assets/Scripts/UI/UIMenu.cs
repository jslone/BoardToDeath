using UnityEngine;
using System.Collections;

public class UIMenu : MonoBehaviour {
	public GameObject menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Toggle() {
		menu.SetActive(!menu.activeSelf);
	}
}
