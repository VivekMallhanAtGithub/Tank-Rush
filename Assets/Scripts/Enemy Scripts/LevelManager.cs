using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Mnager : MonoBehaviour
{
    public Transform player;
    public GameObject enemyToSpawn;

    private Vector3 enemySpawnPosition;

    private float actualSpawnRadius;
    private float actualSpawnAngle;
    public float maxSpawnRadius;
    public float minSpawnRadius;

    private GameObject spawnedEnemy;
    public float enemySpawnFrequency = 1f;
    public float spawnTimer = 0f;
    private int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (score > 100)
        {
            enemySpawnFrequency = 0.2f;
        }
    }

    private void FixedUpdate()
    {
        spawnTimer = spawnTimer + 0.02f;
        if (spawnTimer >= enemySpawnFrequency)
        {
            spawnTimer = 0;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        actualSpawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);
        actualSpawnAngle = Random.Range(0, 360);


        enemySpawnPosition = new Vector3(actualSpawnRadius * Mathf.Cos(actualSpawnAngle), 0f, actualSpawnRadius * Mathf.Sin(actualSpawnAngle));

        spawnedEnemy = Instantiate(enemyToSpawn, enemySpawnPosition, Quaternion.identity);
        spawnedEnemy.GetComponent<EnemyBase>().enemyTarget = player;

    }
}