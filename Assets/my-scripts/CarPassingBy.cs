using UnityEngine;
using System.Collections;

public class CarPassingBy : MonoBehaviour {

	public AudioClip clip;

	private AudioSource audio;
	private bool alreadyPlayed = false;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			if (!alreadyPlayed) {
				alreadyPlayed = true;
				audio.PlayOneShot(clip);
			}
		}
	}
}
