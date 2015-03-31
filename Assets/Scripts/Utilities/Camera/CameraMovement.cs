using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public Camera Camera;
	public CameraSettings[] CameraCheckpoints;
	public float Acceleration;		// Camera acceleration
	public float Drag;				// Rate at which speed decays
	public float Gravity;			// Rate at which camera snaps to closests point, should be less than speed

	public float ZoomLevel = 0.0f;
	private float zoomInput = 0.0f;
	private float zoomSpeed = 0.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// Get current zoom input
		zoomInput = Input.GetAxis("Zoom");

		// Find inbetween
		float scaledZoom = ZoomLevel * (CameraCheckpoints.Length - 1);
		int lower = Mathf.FloorToInt(scaledZoom);
		int upper = Mathf.CeilToInt(scaledZoom);
		float t = scaledZoom - lower;

		// Interpolate camera position
		Vector2 pos = Vector2.Lerp(CameraCheckpoints[lower].Position,CameraCheckpoints[upper].Position,t);
		transform.position = new Vector3(pos.x,pos.y,transform.position.z);

		// Interpolate size
		Camera.orthographicSize = Mathf.Lerp(CameraCheckpoints[lower].Size,CameraCheckpoints[upper].Size,t);

	}

	void FixedUpdate() {
		// Change in speed due to input acceleration
		zoomSpeed += Acceleration * zoomInput * Time.fixedDeltaTime;

		// Change in speed due to snap gravity
		float scaledZoom = ZoomLevel * (CameraCheckpoints.Length - 1);
		float snappedZoom = Mathf.Round(scaledZoom);
		zoomSpeed += Gravity * (snappedZoom - scaledZoom) * Time.fixedDeltaTime;

		// Change in speed due to drag
		zoomSpeed -= Drag * zoomSpeed * Time.fixedDeltaTime;

		// Change in zoom due to speed
		ZoomLevel += zoomSpeed * Time.fixedDeltaTime;
		ZoomLevel = Mathf.Clamp(ZoomLevel,0,1);
	}
}
