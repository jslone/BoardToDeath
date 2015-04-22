using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIUpgradeButton : MonoBehaviour {
	public Button button;
	public Upgradeable upgrade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		button.interactable = upgrade.CanUpgrade();
	}

	public void Upgrade() {
		upgrade.BuyUpgrade();
	}
}
