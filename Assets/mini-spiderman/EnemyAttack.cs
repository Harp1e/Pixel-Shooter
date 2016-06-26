using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public int attackDamage = 60;
	public float timeBetweenAttacks = 0.5f;

	private Animator anim;
	private GameObject player;
	private bool playerInRange = false;
	private float timer;
	private EnemyHealth enemyHealth;
	private PlayerHealth playerHealth;
	private Animator playerAnim;
	private bool isEnabled = true;
	private NavMeshAgent agent;
	private PlayerShoot playerShoot;
	private IronManBehaviourScript playerMovement;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyHealth = GetComponent<EnemyHealth>();
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerAnim = player.GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent>();
		playerShoot = player.GetComponent<PlayerShoot>();
		playerMovement = player.GetComponent<IronManBehaviourScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if( ! isEnabled){
			return;
		}
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0){
			Attack();
		}
		if (playerHealth.currentHealth <= 0){
//			playerAnim.SetTrigger("death");
			playerHealth.Death();

			isEnabled = false;
			anim.SetTrigger("idle");
			agent.enabled = false;
			playerShoot.DisableShooting();
			playerMovement.DisableMovement();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player){
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player){
			playerInRange = false;
		}
	}

	void Attack(){
		timer = 0f;
		anim.SetTrigger("Attack");
		if (playerHealth.currentHealth > 0){
			playerHealth.TakeDamage(attackDamage);
		}
	}
}
