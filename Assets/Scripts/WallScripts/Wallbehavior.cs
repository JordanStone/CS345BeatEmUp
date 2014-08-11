using UnityEngine;
using System.Collections;

public class Wallbehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter(Collision col)
	{
		col.gameObject.rigidbody.AddForce(Vector3.down * 10);
	}
}
