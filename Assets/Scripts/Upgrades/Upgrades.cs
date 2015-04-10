using UnityEngine;using System.Collections;public class Upgrades : MonoBehaviour {
    public GameObject[] Boat0States;
    public GameObject[] Boat1States;
    public GameObject[] Boat2States;

    public int boat0StateIdx = -1;
    public int boat1StateIdx = 0;
    public int boat2StateIdx = -1;

    private GameObject[][] BoatStates;
    private int[] BoatUpgradeState;	// Use this for initialization	void Start () {
        BoatStates = new GameObject[3][];
        BoatUpgradeState = new int[3];

        BoatStates[0] = Boat0States;
        BoatStates[1] = Boat1States;
        BoatStates[2] = Boat2States;

        BoatUpgradeState[0] = boat0StateIdx;
        BoatUpgradeState[1] = boat1StateIdx;
        BoatUpgradeState[2] = boat2StateIdx;	}		// Update is called once per frame	void Update () {	}

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
    }}