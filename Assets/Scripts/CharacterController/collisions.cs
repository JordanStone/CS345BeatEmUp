using UnityEngine;
using System.Collections;

public class collisions : MonoBehaviour {
	protected int damageTaken;

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
			gameObject.transform.GetComponent<Health>().Damage(damageTaken);
		}
		
	}
}
