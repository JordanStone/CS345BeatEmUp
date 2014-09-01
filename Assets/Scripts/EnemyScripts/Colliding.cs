using UnityEngine;
using System.Collections;

public class Colliding : MonoBehaviour {
	protected int damageTaken;
	protected bool right;
	protected Vector3 pos;
	protected Quaternion rot;


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
			gameObject.transform.GetComponent<Health>().Damage(right, damageTaken);
		}
		if(col.transform.gameObject.tag == "ResetBox")
		{
			pos = this.gameObject.GetComponent<EnemyController>().getSpawnPos();
			rot = this.gameObject.GetComponent<EnemyController>().getSpawnRot();
			this.gameObject.transform.position = pos;
			this.gameObject.transform.rotation = rot;
			this.gameObject.GetComponent<Health>().noForceDamage(10);
		}
		
	}
}
