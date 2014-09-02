using UnityEngine;
using System.Collections;

public class spawnPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnPickups(string pick)
	{
		GameObject newPickup = (GameObject) Instantiate (Resources.Load(pick));
		newPickup.transform.position = this.transform.position;
	}
}
