using UnityEngine;
using System.Collections;

public class ResetEnemyWall : MonoBehaviour {

	public GameObject target;
	protected Vector3 resetPos;
	protected int damage = 10;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter2D(Collision2D col)
	{
		//target = col.gameObject;
		resetPos = col.transform.gameObject.GetComponent<EnemyController>().getSpawnPos();
		//resetPos = target.GetComponent<EnemyController>().get
		Debug.Log("Spawnx =" + resetPos.x);
		col.transform.GetComponent<Transform>().position = resetPos;
		col.transform.gameObject.GetComponent<Health>().noForceDamage(damage);
	}
}
