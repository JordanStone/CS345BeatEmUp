using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public float spawnTime = 5f;		
	public float spawnDelay = 3f;
	public GameObject[] enemies;	

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
	}
}
