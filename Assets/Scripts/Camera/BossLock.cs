using UnityEngine;
using System.Collections;
public class BossLock : MonoBehaviour {

	public AudioClip enemyspawn;
	public GameObject mCamera;
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
				//Debug.Log("Enemies null!");
				mCamera.transform.GetComponent<CameraBehavior>().lockActive = false;
				mCamera.transform.GetComponent<CameraBehavior>().lockSet = false;
				Destroy(this.gameObject);
			}
		}
	
	}

	void OnCollisionEnter2D(Collision2D crash){
		mCamera.transform.GetComponent<CameraBehavior>().lockActive = true;
		spawnBoss();
		totalEnemies++;
		this.gameObject.layer = 12;
		active = true;
	}

	void spawnBoss(){
		//float newFloat = (float) num * (0.5f);

		GameObject newEnemy = (GameObject) Instantiate (Resources.Load ("MiniBoss"));
		audio.PlayOneShot (enemyspawn);

		newEnemy.layer = 10;
		newEnemy.transform.position = new Vector2(transform.position.x - 4f, transform.position.y - 2f);
		newEnemy.GetComponent<Origin>().setOrigin(this.gameObject);
		//newEnemy.GetComponent<EnemyController>().setWaitTime(newFloat);
	}

	public void decrementEnemyCounter()
	{
		totalEnemies -= 1;
	}


}