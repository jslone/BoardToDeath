using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Souls : MonoBehaviour {
	public static int souls = 0;
	public static int monsters { get { return monsterList.Count; }}
	public static int heroes { get { return heroList.Count; }}

	private static LinkedList<RPGCharacter> heroList = new LinkedList<RPGCharacter>();
	private static LinkedList<RPGCharacter> monsterList = new LinkedList<RPGCharacter>();

	public RPGCharacter world;
	public float AttackRate;

	// Use this for initialization
	void Start () {
		Invoke("RunAttacks",AttackRate);
	}

	public static void AddMonster(RPGCharacter monster) {
		monsterList.AddLast(monster);
	}

	public static void AddHero(RPGCharacter hero) {
		heroList.AddLast(hero);
	}
	
	// Update is called once per frame
	void RunAttacks () {

		if(monsters == 0 || heroes == 0)
			return;

		LinkedListNode<RPGCharacter> hero = heroList.First;
		LinkedListNode<RPGCharacter> monster = heroList.First;

		while(hero != null && monster != null) {
			RPGCharacter.Fight(hero.Value,monster.Value);

			LinkedListNode<RPGCharacter> nextHero = hero.Next;
			LinkedListNode<RPGCharacter> nextMonster = monster.Next;

			if(hero.Value.Dead) {
				heroList.Remove(hero);
			}
			if(monster.Value.Dead) {
				monsterList.Remove(monster);
			}

			hero = nextHero;
			monster = nextMonster;
		}

		while(monster != null) {
			RPGCharacter.Fight(world,monster.Value);
			monster = monster.Next;

			// Gameover
			if(world.Dead) {

			}
		}
	}
}
