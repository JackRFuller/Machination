using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    

	// Use this for initialization
	void Start () {

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
                Enemies[i].SetActive(true);
                break;
            }
        }
    }
}
