using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Level_Manager : MonoBehaviour
{
    public static Level_Manager Instance;
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

    public ParticleSystem bloodParticlesPrefab;
    private ParticleSystem spawnedBloodParticleSystem;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
    }
    void Start()
    {
        spawnedBloodParticleSystem = Instantiate(bloodParticlesPrefab);
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

    public void SpawnBloodParticleAtLocation(Vector3 Location)
    {
        Debug.Log("Request recieved to spawn particle"+Location);

        EmitParams bloodEmitParams = new EmitParams();
        bloodEmitParams.position = Location;

        spawnedBloodParticleSystem.Emit(bloodEmitParams, 2);
    }
}