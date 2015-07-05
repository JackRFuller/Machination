using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int CurrentScore = 0;
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

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Enemy")
        {
            string HitScore = obj.transform.FindChild("Canvas").FindChild("Score").GetComponent<Text>().text;
            int.TryParse(HitScore,out CurrentScore);
           
        }
    }
}
