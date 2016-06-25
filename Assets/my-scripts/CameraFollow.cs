using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float cameraSmoothing = 5.0f;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetCamera = target.transform.position+ offset;
		transform.position = Vector3.Lerp(transform.position, targetCamera, Time.deltaTime* cameraSmoothing);

	}
}
