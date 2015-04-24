using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boat : Upgradeable {
	public TimedEquations Movement;
	public Line WaitLine;
	public float Capacity;
	public Vector3 FrontOfBoat;
	public Vector3 Offset;

	public bool Docked
	{
		get { return !Movement.enabled; }
		set
		{
			Movement.Reset();
			Movement.enabled = !value;
		}
	}

	private List<GameObject> onBoat = new List<GameObject>();

	private bool approaching = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Docked for a frame, time to take off
		if(Docked) {
			animator.SetInteger("level",UpgradeLevel);
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
				character.GetComponent<Animator>().enabled = false;
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
}
