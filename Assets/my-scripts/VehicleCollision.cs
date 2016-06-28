using UnityEngine;
using System.Collections;

public class VehicleCollision : MonoBehaviour {

	public AudioClip clip;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player"){
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			audioSource.PlayOneShot(clip);
			playerHealth.Death();
		} else if (other.gameObject.tag == "Enemy") {
			EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
			audioSource.PlayOneShot(clip);
			enemyHealth.Death();
		}
	}
}
