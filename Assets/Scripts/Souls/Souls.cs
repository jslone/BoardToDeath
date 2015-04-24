using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Souls : MonoBehaviour {
	public static int souls = 0;
	public static int monsters { get { return monsterList.Count; }}
	public static int heroes { get { return heroList.Count; }}

	private static List<RPGCharacter> heroList = new List<RPGCharacter>();
	private static List<RPGCharacter> monsterList = new List<RPGCharacter>();

	public RPGCharacter world;
	public float AttackRate;
	private float timeSinceAttack;

	// Use this for initialization
	void Start () {
	}

	void Update() {
		timeSinceAttack += GameTime.deltaTime.time;
		if(timeSinceAttack >= AttackRate) {
			RunAttacks();
			timeSinceAttack -= AttackRate;
		}
	}

	public static void AddMonster(RPGCharacter monster) {
		monsterList.Add(monster);
	}

	public static void AddHero(RPGCharacter hero) {
		heroList.Add(hero);
	}

	void RunAttacks () {
		int i;
		for(i = 0; i < monsters && i < heroes; i++) {
			RPGCharacter.Fight(heroList[i],monsterList[i]);
		}

		for(;i < monsters; i++) {
			RPGCharacter.Fight(world,monsterList[i]);
		}

		if(world.Dead) {
			Application.LoadLevel("gameOver");
		}

		PruneDead(monsterList);
		PruneDead(heroList);
	}

	void PruneDead(List<RPGCharacter> list) {
		for(int i = list.Count; i > 0; i--) {
			if(list[i-1].Dead) {
				list.RemoveAt(i-1);
			}
		}
	}
}
