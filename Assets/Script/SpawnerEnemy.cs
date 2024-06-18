using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    [SerializeField] public Transform[] spawnPoints;
    [SerializeField] public float spawnTime = 2f;

    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnTime;
        }
        
    }

    void SpawnEnemy()
    {
        int spawning = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawning];
        GameObject enemyGameObject = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemyGameObject.AddComponent<EnemyAI>();


    }
}
