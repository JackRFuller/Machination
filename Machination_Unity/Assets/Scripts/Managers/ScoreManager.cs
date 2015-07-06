using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	[Header("UI Variables")]
	[SerializeField] private Text Highscore;

    public int CurrentScore = 0;
    public int Score = 0;
    [SerializeField] private float ScoreRate;
    public bool NewScore = false;  


	// Use this for initialization
	void Start () {

		Highscore.text = Highscore.text + PlayerPrefs.GetInt("Highscore").ToString();

        StartCoroutine(ScoreCounter());
	
	}

    public IEnumerator ScoreCounter()
    {
        yield return new WaitForSeconds(ScoreRate);
        Score++;        
        NewScore = true;       
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Enemy")
        {
            string HitScore = obj.transform.FindChild("Canvas").FindChild("Score").GetComponent<Text>().text;
            int.TryParse(HitScore,out CurrentScore);

			if(CurrentScore > PlayerPrefs.GetInt("Highscore"))
			{
				UpdateHighScoreText();
			}


           
        }
    }

	void UpdateHighScoreText()
	{
		Highscore.text = "High Score: " + CurrentScore.ToString();
		PlayerPrefs.SetInt("Highscore", CurrentScore);
	}
}
