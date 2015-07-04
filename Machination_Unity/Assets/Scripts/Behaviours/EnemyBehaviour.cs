using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    [Header("Enemy Attributes")]
    [SerializeField] private float Speed;
    private CharacterController CC_PC;
    private Vector3 moveDirection = Vector3.zero;

    private Camera MainCamera;
    private Vector2 viewportPosition;
    private Vector2 newPosition;

	// Use this for initialization
	void Start () {

        MainCamera = Camera.main;
        CC_PC = GetComponent<CharacterController>();
	
	}

    void Update()
    {
        CheckPosition();
        Move();
    }

    void Move()
    {
        moveDirection.x = Speed * Time.deltaTime;
        CC_PC.Move(moveDirection * Time.deltaTime);
    }

    void CheckPosition()
    {
        newPosition = transform.position;
        viewportPosition = MainCamera.WorldToViewportPoint(newPosition);

        

        if (viewportPosition.x < 0)
        {
            Invoke ("SetInActive", 0F);
        }
    }

    void SetInActive()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
