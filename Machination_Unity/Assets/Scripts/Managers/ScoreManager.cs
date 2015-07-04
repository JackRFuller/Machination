using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int Score = 0;
    [SerializeField] private float ScoreRate;
    public bool NewScore = false;    


	// Use this for initialization
	void Start () {

        StartCoroutine(ScoreCounter());
	
	}

    public IEnumerator ScoreCounter()
    {
        yield return new WaitForSeconds(ScoreRate);
        Score++;
        Debug.Log("Hit");
        NewScore = true;       
    }

    void OnTriggerEnter()
    {

    }
}
