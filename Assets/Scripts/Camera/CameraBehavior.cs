using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public float dampTime = 0.5f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public float posX = 0.5f;
	public float posY = 0.5f;
	public float zDistance = 10f;
	public float lockDistance = 5f;
	public bool lockActive = false;
	public bool lockSet = false;
	protected float xLockMin;
	protected float xLockMax;
	public float cameraOffset = 9.0f; 

	// Use this for initialization
	void Start () {
		transform.position -= new Vector3(0, 0, zDistance);
	
	}
	
	// Update is called once per frame
	void Update () {

		if(target && !lockActive)
		{

			Vector3 point = camera.WorldToViewportPoint(target.position);
			Debug.Log("Target.pos.Z = " + target.position.z);
			//Debug.Log("Point.z = " + point.z);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(posX, posY, point.z)); //zDistance used to be point.z
			Vector3 destination = transform.position + delta;
			//Debug.Log("Destination.z = " + destination.z);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

		if(lockActive && !lockSet)
		{
			transform.position -= new Vector3(0, 0, lockDistance);
			xLockMin = camera.transform.position.x - cameraOffset;
			xLockMax = camera.transform.position.x + cameraOffset;
			GameObject wallLeft = (GameObject) Instantiate (Resources.Load ("InvisibleWall"));
			GameObject wallRight = (GameObject) Instantiate (Resources.Load ("InvisibleWall"));
			wallLeft.transform.position = new Vector2(xLockMin, target.position.y);
			wallRight.transform.position = new Vector2(xLockMax, target.position.y);
			lockSet = true;

		}

	
	}
}
