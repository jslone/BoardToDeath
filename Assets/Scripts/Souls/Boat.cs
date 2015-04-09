using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boat : MonoBehaviour {
	public TimedEquations Movement;
	public Line WaitLine;
	public int Capacity;
	public Vector3 FrontOfBoat;
	public Vector3 Offset;

	private List<GameObject> onBoat = new List<GameObject>();

	private bool approaching = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(approaching && Movement.delta < 0) {

			int roomOnBoat = Capacity;
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
