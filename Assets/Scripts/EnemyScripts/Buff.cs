using UnityEngine;
using System.Collections;

public class Buff : MonoBehaviour {

	public int totalEnemies = 0;
	protected int minionDamage;
	public int myDamage = 10;
	protected Color green = new Color(0.0f, 0.7f, 0.0f, 1.0f);
	protected Color enraged = new Color(0.3f, 0.0f, 0.0f, 1.0f);
	protected bool buffed = false;
	protected bool minions = false;
	protected GameObject leftMinion;
	protected GameObject rightMinion;


	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Health>().setDefaultColor(green);
		this.gameObject.GetComponent<SpriteRenderer>().color = green;
		spawnMinions();

	
	}
	
	// Update is called once per frame
	void Update () {
		if( totalEnemies <= 0 && !buffed)
		{
			this.gameObject.GetComponent<Health>().setDefaultColor(enraged);
			getAngry();
			buffed = true;
		}
	
	}

	void spawnMinions()
	{
		leftMinion = (GameObject) Instantiate (Resources.Load ("placeholderEnemy 1"));
		rightMinion = (GameObject) Instantiate (Resources.Load ("placeholderEnemy 1"));

		 leftMinion.layer = 10;
		 rightMinion.layer = 10;

		 leftMinion.transform.position = new Vector2(transform.position.x - 2f, transform.position.y);
		 rightMinion.transform.position = new Vector2(transform.position.x + 2f, transform.position.y);
		 totalEnemies++;
		 totalEnemies++;
		 leftMinion.GetComponent<Origin>().setOrigin(this.gameObject);
		 rightMinion.GetComponent<Origin>().setOrigin(this.gameObject);
		 minionDamage = leftMinion.GetComponent<EnemyController>().getDamage();
		 minionDamage *= 2;
		 leftMinion.GetComponent<EnemyController>().setDamage(minionDamage);
		 rightMinion.GetComponent<EnemyController>().setDamage(minionDamage);
		 //minions = true;



	}

	public void decrementEnemyCounter()
	{
		totalEnemies -=1;
	}

	void getAngry()
	{
		this.gameObject.GetComponent<EnemyController>().setDamage(myDamage * 2);
		this.gameObject.GetComponent<SpriteRenderer>().color = enraged;
	}

	public void DestroyAnyMinions()
	{
		if(leftMinion != null)
		{
			Destroy(leftMinion);
		}
		if(rightMinion != null)
		{
			Destroy(rightMinion);
		}

	}


}
