using UnityEngine;
using System.Collections;


public class RPGCharacter : MonoBehaviour {
	public Vector2 Health;
	public Vector2 Attack;

	public bool Dead { get { return Health.x <= 0; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Fight(RPGCharacter c1, RPGCharacter c2) {
		if(c1.Dead || c2.Dead) return;

		float atk1 = Random.Range(c1.Attack.x,c1.Attack.y);
		float atk2 = Random.Range(c2.Attack.x,c2.Attack.y);

		c1.Health.x -= atk2;
		c2.Health.x -= atk1;
	}
}
