using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlowTime : MonoBehaviour {
	public float Cooldown;
	public float Duration;
	public float Scale = 1.0f;
	public Button button;

	private bool slowed = false;
	public float timeLeft = 0.0f;
	public float timeTillUse = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(slowed && timeLeft <= 0.0f) {
			Restore();
		}
		timeLeft -= GameTime.deltaTime.unscaled;
		timeTillUse -= GameTime.deltaTime.unscaled;

		button.interactable = timeTillUse <= 0.0f;
	}

	public void Slow() {
		if(timeTillUse <= 0.0f) {
			GameTime.scale *= Scale;
			timeLeft = Duration;
			timeTillUse = Cooldown;
			slowed = true;
		}
	}

	public void Restore() {
		GameTime.scale /= Scale;
		slowed = false;
	}
}
