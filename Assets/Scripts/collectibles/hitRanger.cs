using UnityEngine;
using System.Collections;

public class hitRanger : MonoBehaviour {

	public float exSpeed = 0.5f;
	public int damage = 10;
	public float maxSize = 3f;
	protected bool right;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.gameObject.GetComponent<BoxCollider2D>().size += new Vector2(exSpeed * Time.deltaTime, exSpeed *Time.deltaTime);
		checkEnd();
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		right = col.transform.gameObject.GetComponent<EnemyController>().getFace();
		col.transform.gameObject.GetComponent<Health>().Damage(right, damage);
	}

	void checkEnd()
	{
		if(this.gameObject.GetComponent<BoxCollider2D>().size.x >= maxSize)
		{
			Destroy(this.gameObject);
		}
	}


}
