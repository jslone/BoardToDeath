using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISouls : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Souls: " + Souls.souls;
	}
}
