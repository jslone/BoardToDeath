using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	private Commandable selected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Select or command
		if(Input.GetMouseButtonDown(0)) {
			Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D col = Physics2D.OverlapPoint(point);

			if(col) {
				Commandable com = col.GetComponent<Commandable>();
				Target target = col.GetComponent<Target>();

				if(com) {
					//selected = com;
				}
				if(target) {
					if(selected) {
						selected.UseTarget(target);
					} else {
						target.DoSomething();
					}
				}
			}
		}
	}
}
