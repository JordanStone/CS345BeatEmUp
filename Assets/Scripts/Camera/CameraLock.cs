using UnityEngine;
using System.Collections;
public class CameraLock : MonoBehaviour {

	public AudioClip enemyspawn;
	public GameObject mCamera;
	public int numEnemies = 2;
	public float enemyOffset = 5;
	protected GameObject enemies;
	protected bool active = false;
	public int totalEnemies = 0;
	//protected GameObject LockandRoll;
	// Use this for initialization

	void Start () {
	//LockandRoll = mCamera.transform.GetComponent<CameraBehavior>();
	}
	// Update is called once per frame
	void Update () {

		if(active)
		{
			if(totalEnemies <= 0)
			{
				Debug.Log("Enemies null!");
				mCamera.transform.GetComponent<CameraBehavior>().lockActive = false;
				mCamera.transform.GetComponent<CameraBehavior>().lockSet = false;
				Destroy(this.gameObject);
			}
		}
	
	}

	void OnCollisionEnter2D(Collision2D crash){
		int i=0;
		mCamera.transform.GetComponent<CameraBehavior>().lockActive = true;
		for(i=1; i <= numEnemies; i++)
		{
			//Debug.Log("looping");
			float xDistance = enemyOffset;
			if (i%2 == 0)
			{
				xDistance = -xDistance;
			}

			spawnEnemy(xDistance);
			totalEnemies++;
			//spawnTime(xDistance);
		}
		enemies = GameObject.FindWithTag("Enemy");
		//Destroy(this.gameObject);
		this.gameObject.layer = 12;
		active = true;
	}

	void spawnEnemy(float distance){
		//float newFloat = (float) num * (0.5f);

		GameObject newEnemy = (GameObject) Instantiate (Resources.Load ("placeholderEnemy 1"));
		GetComponent<AudioSource>().PlayOneShot (enemyspawn);

		newEnemy.layer = 10;
		newEnemy.transform.position = new Vector2(transform.position.x + distance, transform.position.y);
		newEnemy.GetComponent<Origin>().setOrigin(this.gameObject);
		//newEnemy.GetComponent<EnemyController>().setWaitTime(newFloat);
	}

	public void decrementEnemyCounter()
	{
		totalEnemies -= 1;
	}

	IEnumerator spawnTime(float d)
	{
		yield return new WaitForSeconds(0.5f);
		spawnEnemy(d);
	}


}