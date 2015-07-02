using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    [Header("Enemy Attributes")]
    [SerializeField] private float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        GetComponent<Rigidbody>().AddForce(Speed * Time.deltaTime, 0, 0);
	
	}
}
