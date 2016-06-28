using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth = 100;
	public Text healthText;
	public Slider healthSlider;
	public float timeToShake = 1.0f;
	public float shakeIntensity = 5.0f;

	private bool isDead = false;
	private Animator anim;
	private float shakingTimer = 0;
	private bool isShaking = false;

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
		if(isShaking && shakingTimer < timeToShake){
			shakingTimer += Time.deltaTime;
			float x = Mathf.PerlinNoise(Camera.main.transform.position.x, Camera.main.transform.position.y);
			Camera.main.transform.position = 
					new Vector3(x * shakeIntensity, Camera.main.transform.position.y, Camera.main.transform.position.z);
		}
		if (shakingTimer >= timeToShake){
			isShaking = false;

		}
	}

	public void TakeDamage(int amount){
		if (isDead){
			return;
		}

		ShakeCamera();
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
	}

	void ShakeCamera (){
		shakingTimer = 0;
		isShaking = true;
	}
}
