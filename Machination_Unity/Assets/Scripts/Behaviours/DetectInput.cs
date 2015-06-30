using UnityEngine;
using System.Collections;

public class DetectInput : MonoBehaviour {

    private PlayerBehaviour PB_Script;

	// Use this for initialization
    void Start()
    {
        PB_Script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
    }

	
	// Update is called once per frame
	void Update () {

       
	
	}
    

    void OnTouchUp()
    {
        PB_Script.Jump();
    }
}
