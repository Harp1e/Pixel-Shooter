using UnityEngine;
using System.Collections;

public class SpawnEnemyScript : MonoBehaviour {

	public GameObject objectToSpawn;
	public float timeToWaitBetweenSpawns = 2.0f;

	private float timer = 0f;
	private IronManBehaviourScript behaviorScript;

	// Use this for initialization
	void Start () {
		timer = 0;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		behaviorScript = player.GetComponent<IronManBehaviourScript>();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log("spawn gameOver: " + behaviorScript.gameOver);
		if (behaviorScript.gameOver == true){
			return;
		} 
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
