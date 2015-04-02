using UnityEngine;
using System.Collections;

public class ScreenPosMarker : MonoBehaviour {
	public Vector2 ScreenPosition;
	// Use this for initialization
	void Start () {
		transform.position = Camera.main.ScreenToWorldPoint(new Vector2(ScreenPosition.x * Screen.width, ScreenPosition.y * Screen.height));
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		transform.position = Camera.main.ScreenToWorldPoint(new Vector2(ScreenPosition.x * Screen.width, ScreenPosition.y * Screen.height));
#endif
	}
}
