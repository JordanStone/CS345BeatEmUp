using UnityEngine;
using System.Collections;

public class Wallbehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//col.gameObject.rigidbody2D.AddForce(col.gameObject.rigidbody2D.velocity * -10000);
	}
}
