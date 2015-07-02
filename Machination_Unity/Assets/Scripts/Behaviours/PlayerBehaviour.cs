using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    [Header("Jumping Variables")]
    [SerializeField] private float JumpStrength;
    [SerializeField] private float Gravity;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController PC_Controller;
    
    

	// Use this for initialization
	void Start () {

       
        PC_Controller = GetComponent<CharacterController>();
	
	}
	
	// Update is called once per frame
	void Update () {

        moveDirection.y -= Gravity * Time.deltaTime;
        PC_Controller.Move(moveDirection * Time.deltaTime);

	}

    public void Jump()
    {
        moveDirection.y = JumpStrength;
		GetComponent<Animation>().Play("Jump");

    }
}
