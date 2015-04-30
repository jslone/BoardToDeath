using UnityEngine;
using System.Collections;

public class PatienceUpgrade : Upgradeable {
	public float[] patienceScales;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Thread.PatienceScale = patienceScales[UpgradeLevel];
	}
}
