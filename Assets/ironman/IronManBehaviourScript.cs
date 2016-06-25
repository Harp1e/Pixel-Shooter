using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class IronManBehaviourScript : MonoBehaviour {

	public float speed;

	private Vector3 movement;
	private Rigidbody playerRigidBody;
	private bool isMoving = false;
	private Animator anim;

	void Awake () {
		playerRigidBody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate(){
		float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		float v = CrossPlatformInputManager.GetAxisRaw("Vertical");
		Move (h, v);
		if (h != 0 || v != 0){
			isMoving = true;
		} else {
			isMoving = false;
		}
		Animating ();
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
}
