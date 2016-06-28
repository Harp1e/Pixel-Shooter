using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IronManBehaviourScript : MonoBehaviour {

	public float speed;
	public bool isEnabled = true;
	public GameObject gameOverPanel;
	public Text scoreText;
	public int score;
	public bool gameOver = false;
	public AudioClip gameOverClip;

	private Vector3 movement;
	private Rigidbody playerRigidBody;
	private bool isMoving = false;
	private Animator anim;
	private int floorMask;
	private float camRayLength = 100f;
	private PlayerHealth playerHealth;
	private AudioSource audio;

	void Awake () {
		playerRigidBody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		floorMask = LayerMask.GetMask("Floor");
	}

	void Start (){
		gameOverPanel.SetActive(false);
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		score = 0;
		scoreText.text = "Score: 0";
		gameOver = false;
		audio = GetComponent<AudioSource>();
	}

	void Update (){
//		Debug.Log("Ironman gameOver: " + gameOver);

		if (playerHealth.currentHealth <= 0){
			isEnabled = false;
			if (gameOver == false){
				Invoke("DisplayGameOver", 1.0f);
			}
		}
		scoreText.text = "Score: " + score.ToString();
	}

	void FixedUpdate(){
		if(isEnabled == false){
			return;
		}
		float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		float v = CrossPlatformInputManager.GetAxisRaw("Vertical");
		Move (h, v);
		if (h != 0 || v != 0){
			isMoving = true;
		} else {
			isMoving = false;
		}
		Animating ();
		Turning ();
	}

	void Move (float h, float v){
		movement.Set (-v, 0f, h);
		movement = movement.normalized * Time.fixedDeltaTime * speed;
		playerRigidBody.MovePosition(transform.position + movement);
	}

	void Animating (){
		if (isMoving){
			anim.SetFloat("speed", 1f); 
		} else {
			anim.SetFloat("speed", 0f); 
		}
	}

	void Turning (){
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)){
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidBody.MoveRotation(newRotation);
		}
	}

	public void DisableMovement(){
		isEnabled = false;
	}

	public void RestartGame (){
		SceneManager.LoadScene("scene-ironman");
	}

	void DisplayGameOver(){
		gameOver = true;
		gameOverPanel.SetActive (true);
		audio.PlayOneShot(gameOverClip, 0.5f);

	}
}
