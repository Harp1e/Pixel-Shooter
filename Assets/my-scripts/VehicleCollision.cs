using UnityEngine;
using System.Collections;

public class VehicleCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player"){
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			playerHealth.Death();
		} else if (other.gameObject.tag == "Enemy") {
			EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
			enemyHealth.Death();
		}
	}
}
