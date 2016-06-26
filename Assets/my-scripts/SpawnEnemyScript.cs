using UnityEngine;
using System.Collections;

public class SpawnEnemyScript : MonoBehaviour {

	public GameObject objectToSpawn;
	public float timeToWaitBetweenSpawns = 2.0f;

	private float timer =0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeToWaitBetweenSpawns){
			timer = 0;
			SpawnEnemy();
		}
	}

	void SpawnEnemy (){
		Instantiate(objectToSpawn, transform.position, transform.rotation);
	}
}
