using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private GameObject player;
	private NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination(player.transform.position);
	}
}
