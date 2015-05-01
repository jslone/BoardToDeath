using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIDescription : MonoBehaviour {
	public Text text;
	public Upgradeable upgrade;
	public string[] Descriptions = new string[Upgradeable.MAX_UPGRADE_LEVEL];
	public string Description;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (upgrade.UpgradeLevel + 1 < Descriptions.Length) {
			Description = Descriptions[upgrade.UpgradeLevel + 1];
			text.text = Description;
		} else {
			text.text = string.Empty;
		}
	}
	
	public void Upgrade() {
	}
}