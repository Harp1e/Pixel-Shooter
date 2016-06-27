using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth = 100;
	public Text healthText;
	public Slider healthSlider;

	private bool isDead = false;
	private Animator anim;

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		anim = GetComponent<Animator>();
		healthSlider.value = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "Health: " + currentHealth.ToString();
		healthSlider.value = currentHealth;
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
		currentHealth = 0;
//		Destroy(gameObject, 3.0f);
	}
}
