using UnityEngine;
using System.Collections;

public class collisions : MonoBehaviour {
	protected int damageTaken;
	protected bool right;
	protected Vector3 pos;
	protected Quaternion rot;
	public GameObject player;

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
			player.gameObject.transform.GetComponent<Health>().Damage(right, damageTaken);
		}
		if(col.transform.gameObject.tag == "ResetBox")
		{
			pos = player.gameObject.GetComponent<CharController>().getSpawnPos();
			rot = player.gameObject.GetComponent<CharController>().getSpawnRot();
			player.gameObject.transform.position = pos;
			player.gameObject.transform.rotation = rot;
			player.gameObject.GetComponent<Health>().noForceDamage(10);

		}
		
	}
}
