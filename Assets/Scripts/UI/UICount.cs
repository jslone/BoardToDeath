using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICount : MonoBehaviour {
	public enum UICountType {
		SOULS,
		MONSTERS,
		HEROES
	};

	public UICountType type;
	public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(type) {
			case UICountType.SOULS:
				text.text = "Souls: " + Souls.souls;
				break;
			case UICountType.HEROES:
				text.text = Souls.heroes.ToString();
				break;
			case UICountType.MONSTERS:
				text.text = Souls.monsters.ToString();
				break;
		}
	}
}
