using UnityEngine;
using System.Collections;

public class Cheats : MonoBehaviour {
	public Boat[] Boats;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
			Boats[0].BuyUpgrade();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
			Boats[1].BuyUpgrade();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
			Boats[2].BuyUpgrade();
        }
		if(Input.GetKey(KeyCode.BackQuote)) {
			Souls.souls++;
		}
	}
}
