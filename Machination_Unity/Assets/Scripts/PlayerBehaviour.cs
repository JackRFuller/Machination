using UnityEngine;
using System.Collections;

public class PlayerBehaviour : LevelManager {

	[SerializeField] private float JumpHeight;
	[SerializeField] private Vector3 Gravity;

	// Use this for initialization
	void Start () {

		Physics.gravity = Gravity;
		JumpHeight = JumpHeight * GameSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
