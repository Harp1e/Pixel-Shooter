using UnityEngine;
using System.Collections;

public class HonkScript : MonoBehaviour {

	public AudioClip honk;

	private AudioSource audio;
	private bool alreadyHonked = false;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") {
			if (!alreadyHonked) {
				alreadyHonked = true;
				audio.PlayOneShot(honk);
			}
		}
	}
}
