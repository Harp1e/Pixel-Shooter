using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Light spotLight;
	public int damagePoints = 10;
	public bool isEnabled = true;
	public AudioClip laser1;
	public AudioClip laser2;
	public AudioClip laser3;
	public AudioClip laser4;

	private RaycastHit shootHit;
	private Ray shootRay;
	private LineRenderer laserLine;
	private int shootableMask;
	private GameObject laserBeamOrigin;
	private GameObject laserBeamEnd;
	private bool isShooting = false;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		shootableMask = LayerMask.GetMask("Enemies");
		laserLine = GetComponentInChildren<LineRenderer>();
		laserBeamOrigin = GameObject.FindGameObjectWithTag("LaserBeamOrigin");
		laserBeamEnd = GameObject.FindGameObjectWithTag("LaserBeamEnd");
		spotLight.enabled = false;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && !isShooting && isEnabled){
			Shoot();
			Invoke("StopShooting", 0.15f);
		} 
	}

	void Shoot() {
		spotLight.enabled = true;
		laserLine.enabled = true;
		isShooting = true;
		laserLine.SetPosition(0, laserBeamOrigin.transform.position);
		shootRay.origin = laserBeamOrigin.transform.position;
		shootRay.direction = transform.forward;
		if (Physics.Raycast(shootRay, out shootHit, 100f, shootableMask)){
			laserLine.SetPosition (1, shootHit.point);
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
			if(enemyHealth != null){
				enemyHealth.TakeDamage(damagePoints, shootHit.point);
			}
		} else {
			laserLine.SetPosition (1, laserBeamEnd.transform.position);
		}
		PlayLaserSound();
	}

	void PlayLaserSound (){
		int randomNumber = Random.Range(1, 4);
		switch(randomNumber){
		case 1:
			audio.PlayOneShot(laser1);
			break;
		case 2:
			audio.PlayOneShot(laser2);
			break;
		case 3:
			audio.PlayOneShot(laser3);
			break;
		case 4:
			audio.PlayOneShot(laser4);
			break;
		}

	}

	void StopShooting () {
		laserLine.enabled = false;
		isShooting = false;
		spotLight.enabled = false;
	}

	public void DisableShooting(){
		isEnabled = false;
	}
}
