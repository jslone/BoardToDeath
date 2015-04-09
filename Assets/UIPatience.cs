using UnityEngine;
using System.Collections;

public class UIPatience : MonoBehaviour {
	public Patience patience;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(patience.started) {
			Vector3 scale = transform.localScale;
			scale.y = Mathf.Max(0,patience.TTL / Patience.MAX);
			transform.localScale = scale;
		}
	}
}
