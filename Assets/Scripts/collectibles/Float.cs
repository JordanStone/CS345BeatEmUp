using UnityEngine;
using System.Collections;

public class Float : MonoBehaviour {
	public float yModMax = 5f;
	public float yIncrement = 0.1f;
	protected float yOrigin;
	protected bool up = false;
	protected Vector3 startPos;
	protected Vector3 modVector;

	// Use this for initialization
	void Start () {
		startPos = this.transform.position;
		yOrigin = startPos.y;
		//modVector = new Vector3(0f, yIncrement * Time.deltaTime, 0f);
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("y pos = " + this.transform.position.y);

		if(up)
		{
			floatUp();
		}
		else
		{
			floatDown();
		}

		if(this.transform.position.y >= yModMax + yOrigin)
		{
			up = false;
		}
		else if(this.transform.position.y < yOrigin)
		{
			up = true;

		}
	
	}

	void floatUp()
	{
		this.transform.position += new Vector3(0f, yIncrement * Time.deltaTime, 0f);
	}

	void floatDown()
	{
		this.transform.position -= new Vector3(0f, yIncrement * Time.deltaTime, 0f);
	}
}
