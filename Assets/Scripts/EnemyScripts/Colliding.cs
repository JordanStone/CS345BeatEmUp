using UnityEngine;
using System.Collections;

public class Colliding : MonoBehaviour {
	protected int damageTaken;
	protected bool right;
	protected Vector3 pos;
	protected Quaternion rot;
	public GameObject enemy;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.transform.gameObject.tag == "PlayerAttack")
		{
			damageTaken = col.transform.gameObject.GetComponent<CharController>().getDamage();
			right = col.transform.gameObject.GetComponent<CharController>().getFace();
			enemy.gameObject.transform.GetComponent<Health>().Damage(right, damageTaken);
		}
		if(col.transform.gameObject.tag == "ResetBox")
		{
			pos = enemy.gameObject.GetComponent<EnemyController>().getSpawnPos();
			rot = enemy.gameObject.GetComponent<EnemyController>().getSpawnRot();
			enemy.gameObject.transform.position = pos;
			enemy.gameObject.transform.rotation = rot;
			enemy.gameObject.GetComponent<Health>().noForceDamage(10);
		}
		
	}
}
