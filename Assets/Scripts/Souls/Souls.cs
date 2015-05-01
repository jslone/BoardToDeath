using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Souls : MonoBehaviour {
	public static int soulsTotal = 0;
	private static int _currentSouls = 0;
	public static int souls
	{
		get { return _currentSouls; }
		set
		{
			soulsTotal += Mathf.Max(value - _currentSouls,0);
			_currentSouls = value;
		}
	}
	public static int monsters { get { return monsterList.Count; }}
	public static int heroes { get { return heroList.Count; }}
	public static int monstersTotal = 0;
	public static int heroesTotal = 0;

	private static List<RPGCharacter> heroList = new List<RPGCharacter>();
	private static List<RPGCharacter> monsterList = new List<RPGCharacter>();

	public RPGCharacter world;
	public float AttackRate;
	private float timeSinceAttack;

	public GameObject mainMenu;
	public GameObject upgradeButton;
	public GameObject Threads;
	public GameObject Docks;
	public Animator menuAnim;

	// Use this for initialization
	void Start () {
	}

	void Awake() {
		monsterList.Clear();
		heroList.Clear();
		soulsTotal = 0;
		_currentSouls = 0;
		monstersTotal = 0;
		heroesTotal = 0;

		GameTime.done = false;
		GameTime.paused = false;
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
		monstersTotal++;
	}

	public static void AddHero(RPGCharacter hero) {
		heroList.Add(hero);
		heroesTotal++;
	}

	public static void ClearMonsters() {
		monsterList.Clear();
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
			if (Tutorial.CurrentTutorial != null) {
				Tutorial.CurrentTutorial.UpdateProgress(-1);
			} else {
				EndGame();
			}
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

	void EndGame() {
		GameTime.done = true;
		mainMenu.SetActive(true);
		menuAnim.SetTrigger("gameOver");

		// Disable interactive buttons and hovering
		upgradeButton.GetComponent<Button>().interactable = false;
		upgradeButton.GetComponent<EventTrigger>().enabled = false;

		BoxCollider2D[] colliders = Threads.GetComponentsInChildren<BoxCollider2D>();
		foreach (BoxCollider2D collider in colliders) {
			collider.enabled = false;
		}
		colliders = Docks.GetComponentsInChildren<BoxCollider2D>();
		foreach (BoxCollider2D collider in colliders) {
			collider.enabled = false;
		}
	}
}
