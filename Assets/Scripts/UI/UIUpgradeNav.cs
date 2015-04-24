using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
		text.text = names[upgrades.loc];
	}

	public void Navigate() {
		upgrades.Move(dir);
	}
}
