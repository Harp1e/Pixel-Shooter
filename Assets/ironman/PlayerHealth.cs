using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth = 100;
	public Text healthText;

	private bool isDead = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		anim = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "Health: " + currentHealth.ToString();
	}

	public void TakeDamage(int amount){
		if (isDead){
			return;
		}
		currentHealth -= amount;
		if (currentHealth <= 0){
			Death();
		}
	}

	public void Death () {
		if (isDead){
			return;
		}
		isDead = true;
		anim.SetTrigger ("death");
//		Destroy(gameObject, 3.0f);
	}
}
