using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIUpgradeButton : MonoBehaviour {
	public Button button;
	public int boatId;
	public Upgrades upgrades;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		button.interactable = upgrades.Boats[boatId].CanUpgrade();
	}

	public void Upgrade() {
		upgrades.BuyBoatUpgrade(boatId);
	}
}
