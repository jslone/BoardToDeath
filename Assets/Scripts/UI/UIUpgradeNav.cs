using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIUpgradeNav : MonoBehaviour {
	public Text text;
	public UIUpgradeMover upgrades;
	public string[] names;
	public int dir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (upgrades.loc < names.Length) {
			text.text = names[upgrades.loc];
		}
	}

	public void Navigate() {
		if (!String.IsNullOrEmpty(text.text)) {
			upgrades.Move(dir);
		}
	}
}
