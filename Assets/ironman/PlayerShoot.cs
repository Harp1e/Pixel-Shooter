using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public Light spotLight;
	
	private RaycastHit shootHit;
	private Ray shootRay;
	private LineRenderer laserLine;
	private int shootableMask;
	private GameObject laserBeamOrigin;
	private GameObject laserBeamEnd;
	private bool isShooting = false;

	// Use this for initialization
	void Start () {
		shootableMask = LayerMask.GetMask("Enemies");
		laserLine = GetComponentInChildren<LineRenderer>();
		laserBeamOrigin = GameObject.FindGameObjectWithTag("LaserBeamOrigin");
		laserBeamEnd = GameObject.FindGameObjectWithTag("LaserBeamEnd");
		spotLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && !isShooting){
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
		} else {
			laserLine.SetPosition (1, laserBeamEnd.transform.position);
		}
	}

	void StopShooting () {
		laserLine.enabled = false;
		isShooting = false;
		spotLight.enabled = false;
	}
}
