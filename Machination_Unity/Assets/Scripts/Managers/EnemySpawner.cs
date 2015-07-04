using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [Header("Enemy Attributes")]
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float SpawnRate;
    [SerializeField] private float MinHeight;
    [SerializeField] private float MaxHeight;
    [SerializeField] private Vector3 SpawnPosition;    

    [Header("Object Pooling Attributes")]
    [SerializeField] private int pooledAmount = 10;
    List<GameObject> Enemies;

    [Header("Score Variables")]
    [SerializeField]
    private ScoreManager SM_Script;
     
    

	// Use this for initialization
	void Start () {

        SM_Script = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        Enemies = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject SpawnedEnemy = (GameObject)Instantiate(Enemy);
            SpawnedEnemy.SetActive(false);
            Enemies.Add(SpawnedEnemy);
        }

        SpawnPosition = new Vector2(15, 0);
        InvokeRepeating("SpawnEnemies", SpawnRate, SpawnRate);
	
	}

    void SpawnEnemies()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (!Enemies[i].activeInHierarchy)
            {
                SpawnPosition.y = Random.Range(MinHeight, MaxHeight);
                Enemies[i].transform.position = SpawnPosition;
                Enemies[i].transform.rotation = Enemies[i].transform.rotation;

                if (SM_Script.NewScore)
                {
                    Text Score = Enemies[i].transform.FindChild("Canvas").FindChild("Score").GetComponent<Text>();
                    Score.text = SM_Script.Score.ToString();

                    float ScoreYPos = Score.transform.localPosition.y;

                    if (SpawnPosition.y < 0)
                    {
                        ScoreYPos = -ScoreYPos;
                        Score.transform.localPosition = new Vector3(Score.transform.localPosition.x, ScoreYPos, Score.transform.localPosition.z);
                    }
                    else
                    {
                        ScoreYPos = -0.72F;
                        Score.transform.localPosition = new Vector3(Score.transform.localPosition.x, ScoreYPos, Score.transform.localPosition.z);
                    }
                    
                    Score.enabled = true;
                    
                    SM_Script.NewScore = false;
                    StartCoroutine(SM_Script.ScoreCounter());
                }

                Enemies[i].SetActive(true);
                break;
            }
        }
    }
}
