using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boat : MonoBehaviour {
	public TimedEquations Movement;
	public Line WaitLine;
	public float Capacity;
	public Vector3 FrontOfBoat;
	public Vector3 Offset;
    public float Cost;
	public bool Docked
	{
		get { return !Movement.enabled; }
		set
		{
			Movement.Reset();
			Movement.enabled = !value;
		}
	}
	public int UpgradeLevel;
	public static int MAX_UPGRADE_LEVEL = 4;

	private List<GameObject> onBoat = new List<GameObject>();
	private Animator anim;


	private bool approaching = true;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// Docked for a frame, time to take off
		if(Docked) {
			anim.SetInteger("level",UpgradeLevel);
			Docked = false;
		} 
		// Reached the dock and ready for boarding
		else if(approaching && Movement.delta < 0) {
			Docked = true;
		}

		// Stuff to do while docked
		if(Docked) {
			int roomOnBoat = Mathf.RoundToInt(Capacity);
			Vector3 posInBoat = FrontOfBoat;
			while(roomOnBoat > 0 && WaitLine.Length > 0) {
				CharacterLine character = WaitLine.Remove();
				character.GetComponent<Patience>().enabled = false;
				character.enabled = false;

				GameObject soul = character.gameObject;
				Vector3 scale = soul.transform.localScale;
				soul.transform.parent = transform;
				soul.transform.localScale = scale;
				soul.transform.localPosition = posInBoat;
				onBoat.Add(soul);

				roomOnBoat--;
				posInBoat += Offset;
			}
			approaching = false;
		}

		// Stuff to do at end of road
		if(!approaching && Movement.delta > 0) {

			foreach(GameObject soul in onBoat) {
				Destroy(soul);
			}
			Souls.souls += onBoat.Count;
			onBoat.Clear();
			approaching = true;
		}
	}

	public bool CanUpgrade() {
		return UpgradeLevel < MAX_UPGRADE_LEVEL && Cost <= Souls.souls && (!anim || anim.GetInteger("level") == UpgradeLevel);
	}

	public void Upgrade() {
		gameObject.SetActive(true);
		UpgradeLevel++;
	}
}
