using UnityEngine;
using System.Collections;

public class Patience : MonoBehaviour {
	public float LifeSpan { get; private set; }
	public float TTL;

	void Awake() {
		LifeSpan = TTL;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		TTL -= GameTime.deltaTime.time;
		if(TTL < 0) {
			Turn();
		}
	}

	void Turn() {
		GetComponent<Animator>().SetTrigger("monster");
	}

	void Rage() {
		Souls.AddMonster(GetComponent<RPGCharacter>());
		foreach(TimedEquations eq in GetComponents<TimedEquations>())
		{
			eq.enabled = true;
		}
		foreach(TraceEquation te in GetComponents<TraceEquation>())
		{
			te.enabled = true;
		}
		foreach(Sine sn in GetComponents<Sine>())
		{
			sn.Period = Random.Range(7,13);
		}
		GetComponent<CorrectOffset>().enabled = true;
		SpriteRenderer r = GetComponent<SpriteRenderer>();
		Color color = r.color;
		color.a = 0.75f;
		r.color = color;	
	}
}
