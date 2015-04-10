using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {
    public GameObject[] Boat0States;
    public GameObject[] Boat1States;
    public GameObject[] Boat2States;

    public int boat0StateIdx = -1;
    public int boat1StateIdx = 0;
    public int boat2StateIdx = -1;

    private GameObject[][] BoatStates;
    private int[] BoatUpgradeState;
    private int[] pendingUpgrades;
    private bool[] movingLeft;

	// Use this for initialization
	void Start () {
        BoatStates = new GameObject[3][];
        BoatUpgradeState = new int[3];
        pendingUpgrades = new int[3];
        movingLeft = new bool[3];

        BoatStates[0] = Boat0States;
        BoatStates[1] = Boat1States;
        BoatStates[2] = Boat2States;

        BoatUpgradeState[0] = boat0StateIdx;
        BoatUpgradeState[1] = boat1StateIdx;
        BoatUpgradeState[2] = boat2StateIdx;

        pendingUpgrades[0] = 0;
        pendingUpgrades[1] = 0;
        pendingUpgrades[2] = 0;
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

        for (int i = 0; i < 3; i++)
        {
            if (BoatUpgradeState[i] < 0)
            {
                while (pendingUpgrades[i] != 0)
                {
                    UpgradeBoat(i);
                    pendingUpgrades[i]--;
                }
            }
            // When flipping direction
            else if (movingLeft[i] && BoatStates[i][BoatUpgradeState[i]].transform.localScale.x < 0)
            {
                while (pendingUpgrades[i] != 0)
                {
                    UpgradeBoat(i);
                    pendingUpgrades[i]--;
                }
                movingLeft[i] = false;
            }
            else
            {
                movingLeft[i] = BoatStates[i][BoatUpgradeState[i]].transform.localScale.x > 0;
            }
        }
	}

    public void BuyBoatUpgrade(int boatId) {

        if (BoatUpgradeState[boatId] + pendingUpgrades[boatId] + 1 < BoatStates[boatId].Length)
        {
            int cost = BoatStates[boatId][BoatUpgradeState[boatId] + 1].GetComponent<Boat>().Cost;
            Debug.Log(cost);
            Debug.Log(Souls.souls);
            if (cost <= Souls.souls)
            {
                Souls.souls -= cost;
                pendingUpgrades[boatId]++;
            }
        }
    }

    void UpgradeBoat(int boatId)
    {
        if (0 <= BoatUpgradeState[boatId] && BoatUpgradeState[boatId] < BoatStates[boatId].Length - 1)
        {
            BoatStates[boatId][BoatUpgradeState[boatId]].SetActive(false);
        }
        if (0 <= BoatUpgradeState[boatId] + 1 && BoatUpgradeState[boatId] + 1 < BoatStates[boatId].Length)
        {
            BoatStates[boatId][++BoatUpgradeState[boatId]].SetActive(true);
        }
    }
}
