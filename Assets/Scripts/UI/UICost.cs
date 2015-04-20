using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICost : MonoBehaviour {
	public Text text;
	public Upgradeable upgrade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = upgrade.UpgradeLevel < Boat.MAX_UPGRADE_LEVEL ? "Cost: " + upgrade.Cost : "";
	}
}
