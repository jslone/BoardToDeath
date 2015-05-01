using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDescription : MonoBehaviour {
	public Text text;
	public Upgradeable upgrade;
	public string[] Descriptions = new string[Upgradeable.MAX_UPGRADE_LEVEL];
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (upgrade.UpgradeLevel + 1 < Descriptions.Length) {
			text.text = Descriptions[upgrade.UpgradeLevel + 1];
		} else {
			text.text = string.Empty;
		}
	}
	
	public void Upgrade() {
	}
}