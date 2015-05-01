using UnityEngine;
using System.Collections;

public class Cheats : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.BackQuote)) {
			Souls.souls++;
		}
		if(Input.GetKey(KeyCode.Backspace)) {
			PlayerPrefs.DeleteAll();
		}
		if(Input.GetKey(KeyCode.Alpha0)) {
			SoulSpawner.UseSpawner();
		}
	}
}
