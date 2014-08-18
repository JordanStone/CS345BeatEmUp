using UnityEngine;
using System.Collections;
public class CameraLock : MonoBehaviour {
	public GameObject mCamera;
	public int numEnemies = 2;
	public float enemyOffset = 5;
	protected GameObject enemies;
	protected bool active = false;
	//protected GameObject LockandRoll;
	// Use this for initialization

	void Start () {
	//LockandRoll = mCamera.transform.GetComponent<CameraBehavior>();
	}
	// Update is called once per frame
	void Update () {

		if(active)
		{
			if(enemies == null)
			{
				Debug.Log("Enemies null!");
				mCamera.transform.GetComponent<CameraBehavior>().lockActive = false;
				Destroy(this.gameObject);
			}
		}
	
	}

	void OnCollisionEnter2D(Collision2D crash){
		
		mCamera.transform.GetComponent<CameraBehavior>().lockActive = true;
		for(int i=1; i <= numEnemies; i++)
		{
			float xDistance = enemyOffset;
			if (i%2 == 0)
			{
				xDistance = -xDistance;
			}
			spawnEnemy(xDistance);
		}
		enemies = GameObject.FindWithTag("Enemy");
		//Destroy(this.gameObject);
		this.gameObject.layer = 12;
		active = true;
	}

	void spawnEnemy(float distance){
		GameObject newEnemy = (GameObject) Instantiate (Resources.Load ("placeholderEnemy"));
		newEnemy.layer = 10;
		newEnemy.transform.position = new Vector2(transform.position.x + distance, transform.position.y);
	}
}