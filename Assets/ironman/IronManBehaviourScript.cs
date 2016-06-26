using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class IronManBehaviourScript : MonoBehaviour {

	public float speed;
	public bool isEnabled = true;

	private Vector3 movement;
	private Rigidbody playerRigidBody;
	private bool isMoving = false;
	private Animator anim;
	private int floorMask;
	private float camRayLength = 100f;

	void Awake () {
		playerRigidBody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		floorMask = LayerMask.GetMask("Floor");
	}

	void FixedUpdate(){
		if(!isEnabled){
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
//		Debug.Log("RHoriz: " + Input.GetAxis("RHoriz"));
//		Debug.Log("RVert: " + Input.GetAxis("RVert"));
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
}
