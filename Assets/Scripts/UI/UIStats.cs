using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIStats : MonoBehaviour {
	public enum Type {
		SOULS,
		HEROES,
		MONSTERS,
		DISASTERS
	};

	public Type type;
	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switch(type) {
			case Type.SOULS:
				text.text = "Current:\t" + Souls.souls + "\n"
						+	"Spent:\t\t" + (Souls.soulsTotal - Souls.souls) + "\n"
						+	"Total:\t\t" + Souls.soulsTotal;
				break;
			case Type.HEROES:
				text.text = "Current:\t" + Souls.heroes + "\n"
						+	"Killed:\t\t" + (Souls.heroesTotal - Souls.heroes) + "\n"
						+	"Total:\t\t" + Souls.heroesTotal;
				break;
			case Type.MONSTERS:
				text.text = "Current:\t" + Souls.monsters + "\n"
						+	"Killed:\t\t" + (Souls.monstersTotal - Souls.monsters) + "\n"
						+	"Total:\t\t" + Souls.monstersTotal;
				break;
			case Type.DISASTERS:
				text.text = "Total:\t\t" + NaturalDisaster.count;
				break;
		}
	}
}
