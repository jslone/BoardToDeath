using UnityEngine;
using System.Collections;

public class UISelectable : MonoBehaviour {
	public Renderer spriteRenderer;
	public float HoverOpacity = 0.5f;
	Color oldColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseEnter() {
		Highlight(true);
	}

	void OnMouseExit() {
		Highlight(false);
	}

	// highlight sprite by changing transparency
	public void Highlight(bool on) {
		if (on) {
			oldColor = spriteRenderer.material.color;
			Color newColor = oldColor;
			newColor.a = HoverOpacity;
			spriteRenderer.material.color = newColor;
		} else {
			spriteRenderer.material.color = oldColor;
		}
	}
}