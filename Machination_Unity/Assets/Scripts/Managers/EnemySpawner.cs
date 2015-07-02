using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    [Header("Enemy Attributes")]
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float SpawnRate;
    [SerializeField] private float MinHeight;
    [SerializeField] private float MaxHeight;
    [SerializeField] private Vector3 SpawnPosition;

    private Camera MainCamera;
    

	// Use this for initialization
	void Start () {

        MainCamera = Camera.main;
        SpawnPosition = new Vector2(15, 0);
        StartCoroutine(SpawnLocation());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnLocation()
    {
        yield return new WaitForSeconds(SpawnRate);
        SpawnPosition.y = Random.Range(MinHeight, MaxHeight);
        SpawnEnemies();
    }   

    void SpawnEnemies()
    {
        GameObject EnemyClone;
        EnemyClone = Instantiate(Enemy, SpawnPosition, Enemy.transform.rotation) as GameObject;
        StartCoroutine(SpawnLocation());
    }
}
