using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth = 100;

	private bool isDead = false;
	private Animator anim;
	private NavMeshAgent navMeshAgent;
	private ParticleSystem hitParticles;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		anim = GetComponent<Animator>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		hitParticles = GetComponent<ParticleSystem>();

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
			Death();
		}
	}

	void Death () {
		isDead = true;
		anim.SetTrigger ("death");
//		navMeshAgent.enabled = false;
		navMeshAgent.speed = 0;
		Destroy(gameObject, 3.0f);
	}
}
