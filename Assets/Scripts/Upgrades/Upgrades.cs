using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {
	public Boat[] Boats;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuyBoatUpgrade(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuyBoatUpgrade(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuyBoatUpgrade(2);
        }
		if(Input.GetKey(KeyCode.BackQuote)) {
			Souls.souls++;
		}
	}

    public void BuyBoatUpgrade(int boatId) {
		if(Boats[boatId].CanUpgrade()) {
			Souls.souls -= Mathf.RoundToInt(Boats[boatId].Cost);
			Boats[boatId].Upgrade();
		}
    }
}
