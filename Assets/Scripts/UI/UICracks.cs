using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UICracks : MonoBehaviour {
	public RPGCharacter World;
	public List<Sprite> Sprites;
	public List<float> Thresholds;
	Image[] images;

	// Use this for initialization
	void Start () {
		images = gameObject.GetComponentsInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		float scale = World.Health.x / World.Health.y;
		int index;
		for (index = 0; index < Thresholds.Count && index < Sprites.Count; index++) {
			if (scale > Thresholds[index]) {
				break;
			}
		}
		Sprite sprite = (index <= 0 ? null : Sprites[index - 1]);

		// Update sprites of cracks
		foreach (Image image in images) {
			if (sprite == null) {
				image.enabled = false;
			} else {
				image.enabled = true;
				image.sprite = sprite;
			}
		}
	}
}
