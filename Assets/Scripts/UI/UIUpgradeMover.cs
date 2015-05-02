using UnityEngine;
using System.Collections;

public class UIUpgradeMover : MonoBehaviour {
	public RectTransform rTrans;
	public float speed;
	public int loc;
	public float[] positions;

	// Use this for initialization
	void Start () {
		rTrans = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = rTrans.localPosition;
		pos.x = Mathf.Lerp(pos.x,positions[loc],speed * Time.deltaTime);
		rTrans.localPosition = pos;
	}

	public void Move(int dir) {
		loc = (loc + dir + positions.Length) % positions.Length;
	}
}
