using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

	public GameObject mCamera;
	//protected GameObject LockandRoll;

	// Use this for initialization
	void Start () {
		//LockandRoll = mCamera.transform.GetComponent<CameraBehavior>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D crash)
	{
		mCamera.transform.GetComponent<CameraBehavior>().lockActive = true;
		Destroy(this.gameObject);
	}
}
