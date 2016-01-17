using UnityEngine;
using System.Collections;

public class Thread : MonoBehaviour {
	public int soulIdx;
	public Gaussian patienceEquation;
	public PositionalEquations patience;
	public SpriteRenderer spriteRenderer;
	public RPGCharacter potentialMonster;

	public Color goodColor;
	public Color badColor;
	public Color badThreadColor;
	private bool monsterSpawned = false;

	public static float PatienceScale = 1.0f;

	// Use this for initialization
	void Start () {
		patienceEquation.Width *= PatienceScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(!monsterSpawned && patience.position >= 0.8f) {
			Souls.AddMonster(potentialMonster);
			transform.parent.GetComponent<ThreadTarget>().SetColor(badThreadColor);
			monsterSpawned = true;
		}
		spriteRenderer.color = Color.Lerp(goodColor, badColor, 2.5f * patience.position - 1.25f);
	}

	public virtual void Cut() {
		// kill living monster
		potentialMonster.Health.x = 0;

		// Spawn soul
		GameObject soul = SoulSpawner.UseSpawner(soulIdx);

		// Set soul's patience
		if(soul) {
			Patience sp = soul.GetComponent<Patience>();
			sp.TTL *= patience.value;
			sp.enabled = true;
		}

		// Break thread
		Destroy(gameObject);
	}
}
