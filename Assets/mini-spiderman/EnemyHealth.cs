using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth = 100;
	public int pointValueOnKill = 10;
	public AudioClip hurt1;
	public AudioClip hurt2;
	public AudioClip hurt3;
	public AudioClip scoreUp;

	private bool isDead = false;
	private Animator anim;
	private NavMeshAgent navMeshAgent;
	private ParticleSystem hitParticles;
	private AudioSource audio;


	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		anim = GetComponent<Animator>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		hitParticles = GetComponent<ParticleSystem>();
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int amount, Vector3 hitPoint){
		if (isDead){
			return;
		}
		currentHealth -= amount;
		hitParticles.transform.position = hitPoint;
		hitParticles.Play();
		if (currentHealth <= 0){
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			IronManBehaviourScript playerScript = player.GetComponent<IronManBehaviourScript>();
			playerScript.score += pointValueOnKill;
			audio.PlayOneShot(scoreUp, 1.0f); 
			Death();
		}
		PlayLaserSound();
	}

	void PlayLaserSound (){
		int randomNumber = Random.Range(1, 3);
		switch(randomNumber){
		case 1:
			audio.PlayOneShot(hurt1, 0.5f);
			break;
		case 2:
			audio.PlayOneShot(hurt2, 0.5f);
			break;
		case 3:
			audio.PlayOneShot(hurt3, 0.5f);
			break;
		}
	}

	public void Death () {
		isDead = true;
		anim.SetTrigger ("death");
//		navMeshAgent.enabled = false;
		currentHealth = 0;
		navMeshAgent.speed = 0;
		Destroy(gameObject, 3.0f);
	}
}
