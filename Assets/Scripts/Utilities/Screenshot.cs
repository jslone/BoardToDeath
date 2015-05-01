using UnityEngine;
using System.Collections;
using System.IO;

public class Screenshot : MonoBehaviour {
	public float WaitTime = 5f;
	static int count = 0;
	static Screenshot _instance = null;
	// Use this for initialization
	void Awake () {
		if(_instance == null) {
			_instance = this;
			DontDestroyOnLoad(gameObject);
			#if UNITY_EDITOR
			if (!Directory.Exists("Screenshots")) {
				Directory.CreateDirectory("Screenshots");
			}
			InvokeRepeating("Take", WaitTime, WaitTime);
			#endif
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Take() {
		Debug.Log("screenshot " + count);
		Application.CaptureScreenshot("Screenshots/screenshot" + count++ + ".png");
	}
}
