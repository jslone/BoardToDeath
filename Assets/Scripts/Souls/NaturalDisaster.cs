using UnityEngine;
using System.Collections;

public class NaturalDisaster : RandomEvent {
	[System.Serializable]
	public struct Disaster
	{
		public string message;
		public int min,max;
	}

	public GameObject Message;
	public float duration;
	public Disaster[] disasters;

	protected override void Event () {
		int eventId = Random.Range(0,disasters.Length);
		int numSouls = Random.Range(disasters[eventId].min, disasters[eventId].max);

		CreateMessage(transform.position,disasters[eventId].message, duration);
		for(int i = 0; i < numSouls; i++) {
			SoulSpawner.UseSpawner().GetComponent<Patience>().enabled = true;
		}
	}

	protected GameObject CreateMessage(Vector3 pos, string text, float duration) {
		GameObject message = Instantiate(Message, pos, Quaternion.identity) as GameObject;
		Vector3 scale = message.transform.localScale;
		message.transform.SetParent(transform);
		message.transform.localScale = scale;
		message.GetComponent<UIMessage>().MessageText = text;
		message.GetComponent<UIMessage>().Duration = duration;
		return message;
	}
}
