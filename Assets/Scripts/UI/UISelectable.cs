using UnityEngine;
using System.Collections;

public class UISelectable : MonoBehaviour {
	public Renderer spriteRenderer;
	const float HOVER_OPACITY = 0.5f;
	Color oldColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseEnter() {
		oldColor = spriteRenderer.material.color;
		Color newColor = oldColor;
		newColor.a = HOVER_OPACITY;
		spriteRenderer.material.color = newColor;
	}

	void OnMouseExit() {
		spriteRenderer.material.color = oldColor;
	}
}