using UnityEngine;
using System.Collections;

public class Thread : MonoBehaviour {
	public int soulIdx;
	public Logistic positionEquation;
	public TimedEquations position;
	public TimedEquations patience;
	public SpriteRenderer renderer;
	public RPGCharacter potentialMonster;

	public Color goodColor;
	public Color badColor;
	private bool monsterSpawned = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!monsterSpawned && positionEquation.Height - position.value < 0.01f) {
			Souls.AddMonster(potentialMonster);
			monsterSpawned = true;
		}
		renderer.color = Color.Lerp(goodColor, badColor, 2.5f*position.value/positionEquation.Height - 1.25f);
	}

	public virtual void Cut() {
		// kill living monster
		potentialMonster.Health.x = 0;

		// Spawn soul
		GameObject soul = SoulSpawner.UseSpawner(soulIdx);

		// Set souls patience
		if(soul) {
			Patience sp = soul.GetComponent<Patience>();
			sp.TTL *= patience.value;
			sp.enabled = true;
		}

		// Break thread
		Destroy(gameObject);
	}
}
