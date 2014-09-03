using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int health = 1;
	protected int maxHealth = 100;
	public float colorTime = 0.2f;
	public float forceCoefficient = 500f;
	public bool isPlayer = false;
	public bool isBoss = false;
	protected Color defaultColor = Color.white;
	protected Color damageColor = new Color(0.8f, 0.0f, 0.0f, 1.0f);
	protected Color plusColor = new Color(0.0f, 0.9f, 0.0f, 1.0f);
	//protected bool colorCool = false;

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
		GlobalConditions.onDeath(isPlayer); //Runs any relevant onDeath scripts
		if(!isPlayer && !isBoss)
		{
			int choice = getRandom();
			GameObject origin = this.gameObject.GetComponent<Origin>().getOrigin();
			if(origin.GetComponent<CameraLock>() != null)
			{
				origin.GetComponent<CameraLock>().decrementEnemyCounter();
			}
			else
			{
				origin.GetComponent<Buff>().decrementEnemyCounter();
			}
			
			parseRandom(choice);

		}
		if(isBoss)
		{
			GameObject origin = this.gameObject.GetComponent<Origin>().getOrigin();
			origin.GetComponent<BossLock>().decrementEnemyCounter();
			this.gameObject.GetComponent<Buff>().DestroyAnyMinions();
			this.gameObject.GetComponent<spawnPickup>().spawnPickups("BossPickup");
		}
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
		if(this.health > this.maxHealth)
		{
			this.health = this.maxHealth;
		}
		StartCoroutine(plusHealth());

	}
	
	public void noForceDamage(int d)
	{
		this.health -= d;
	}

	public void Damage(bool r, int d)
	{
		this.health -= d;
		//this.gameObject.transform.GetComponent<SpriteRenderer>().color = damageColor;
		//this.gameObject.rigidbody2D.AddForce(new Vector2(d * 300, 0f));
		StartCoroutine(DamageComponents(r, d));
	}

	IEnumerator DamageComponents(bool right, int d)
	{
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = damageColor;
		//damageForce();
		//this.gameObject.rigidbody2D.AddForce(new Vector2(d * forceCoefficient, 0f));
		if( right)
		{
			this.gameObject.rigidbody2D.AddForce(new Vector2(d * forceCoefficient, 0f));
		}
		else
		{
			this.gameObject.rigidbody2D.AddForce(new Vector2(d * -forceCoefficient, 0f));
		}

		yield return new WaitForSeconds(colorTime);
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = defaultColor;
	}

	IEnumerator plusHealth()
	{
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = plusColor;
		yield return new WaitForSeconds(colorTime);
		this.gameObject.transform.GetComponent<SpriteRenderer>().color = defaultColor;
	}

	int getRandom()
	{
		return Random.Range(0, 10);
	}

	void parseRandom(int r)
	{
		if(r >= 8)
		{
			Debug.Log("r =" + r);
			this.gameObject.GetComponent<spawnPickup>().spawnPickups("HealthPickup");
		}
	}

	public void setDefaultColor(Color c)
	{
		defaultColor = c;

	}

}
