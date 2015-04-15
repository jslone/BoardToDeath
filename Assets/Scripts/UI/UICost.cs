using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICost : MonoBehaviour {
	public Text text;
	public Boat boat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = boat.UpgradeLevel < Boat.MAX_UPGRADE_LEVEL ? "Cost: " + boat.Cost : "";
	}
}
