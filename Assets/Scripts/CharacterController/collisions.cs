using UnityEngine;
using System.Collections;

public class collisions : MonoBehaviour {
	protected int damageTaken;
	protected bool right;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.gameObject.tag == "EnemyAttack")
		{
			damageTaken = col.transform.gameObject.GetComponent<EnemyController>().getDamage();
			right = col.transform.gameObject.GetComponent<EnemyController>().getFace();
			gameObject.transform.GetComponent<Health>().Damage(right, damageTaken);
		}
		
	}
}
