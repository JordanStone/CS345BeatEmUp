using UnityEngine;
using System.Collections;

public class Origin : MonoBehaviour {
	public GameObject origins;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setOrigin(GameObject o)
	{
		origins = o;
	}

	public GameObject getOrigin()
	{
		return origins;
	}

}
