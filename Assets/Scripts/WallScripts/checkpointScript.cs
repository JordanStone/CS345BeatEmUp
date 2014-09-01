using UnityEngine;
using System.Collections;

public class checkpointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		col.transform.gameObject.GetComponent<CharController>().spawnPos = this.transform.position;
		Destroy(this.gameObject);
	}
}
