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
		text.text = upgrade.UpgradeLevel < upgrade.MaxUpgradeLevel - 1 ? "Cost: " + upgrade.Cost : "MAX";
	}
}
