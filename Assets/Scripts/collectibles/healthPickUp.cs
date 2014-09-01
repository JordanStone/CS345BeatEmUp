using UnityEngine;
using System.Collections;

public class healthPickUp : MonoBehaviour {
	public int plusHealth = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		col.transform.gameObject.GetComponent<Health>().addHealth(plusHealth);
		Destroy(this.gameObject);
	}

	public void setPlusHealth(int h)
	{
		plusHealth = h;
	}

	public int getPlusHealth()
	{
		return plusHealth;
	}
}
