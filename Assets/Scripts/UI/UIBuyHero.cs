using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIBuyHero : MonoBehaviour {
	public GameObject heroPrefab;
	public int Cost;

	public Button button;
	public Text text;
	// Use this for initialization
	void Start () {
		text.text = "Cost: " + Cost;
	}
	
	// Update is called once per frame
	void Update () {
		button.interactable = CanBuy();
	}

	public bool CanBuy() {
		return Cost <= Souls.souls;
	}

	public void Buy() {
		if(CanBuy()) {
			Souls.souls -= Cost;
			GameObject hero = GameObject.Instantiate(heroPrefab) as GameObject;
			Souls.AddHero(hero.GetComponent<RPGCharacter>());
		}
	}
}
