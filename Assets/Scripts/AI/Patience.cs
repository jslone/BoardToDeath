﻿using UnityEngine;
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
		float lastPeriod = -1;
		foreach(Sine sn in GetComponents<Sine>())
		{
			do
			{
				sn.Period = Random.Range(7,13);
			}
			while(Mathf.Abs(sn.Period - lastPeriod) < 0.5f);
			lastPeriod = sn.Period;

		}
		GetComponent<CorrectOffset>().enabled = true;
		SpriteRenderer r = GetComponent<SpriteRenderer>();
		Color color = r.color;
		color.a = 0.75f;
		r.color = color;	
	}
}
