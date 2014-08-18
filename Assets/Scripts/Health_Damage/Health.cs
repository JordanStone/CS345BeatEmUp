using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int health = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(health <= 0)
		{
			Death();
		}
	
	}

	public void Death(){
		Destroy(this.gameObject);
	}

	public int getHealth()
	{
		return this.health;
	}

	public void setHealth(int h)
	{
		this.health = h;
	}

	public void addHealth(int h)
	{
		this.health += h;
	}

	public void Damage(int d)
	{
		this.health -= d;
		this.gameObject.rigidbody2D.AddForce(new Vector2(d * 20, 0f));
	}

}
