using UnityEngine;

[System.Serializable]
public struct Wave
{
    public int[] enemyIDs;
    public float enemyMinimum;
    public float spawnInterval;

    public int[] bossesIDs;
}

public class EnemySpawner : MonoBehaviour
{
    [Header("Минута волны = индекс (как в vampire-survivors)")]
    public Wave[] waves;

    private Wave currentWave;

    public float distanceSpawn = 24f;

    private float spawnIntervalCounter = 0f;

    private void Awake()
    {
        Timer.Instance.OnMinuteElapsed += NewWave;
        NewWave(0);
    }

    private void NewWave(int minutes)
    {
        currentWave = waves[minutes+1];
        SpawnEnemies();
    }

    private void Update()
    {
        spawnIntervalCounter += Time.deltaTime;

        if (spawnIntervalCounter > currentWave.spawnInterval)
        {
            spawnIntervalCounter = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        LevelManager.Instance.MakeEnemy(GenPosition(), GenIndex());
        
    }

    private void SpawnEnemies()
    {
        var count = Random.Range(0, (int)(currentWave.enemyMinimum * 0.5f));

        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
        }
    }

    private int GenIndex()
    {
        var idIndex = Random.Range(0, currentWave.enemyIDs.Length);
        var id = currentWave.enemyIDs[idIndex];

        return id;
    }

    private Vector3 GenPosition()
    {
        var playerPos = Player.Instance.transform.position;

        var pos = playerPos;

        while(Vector2.Distance(pos, playerPos) < distanceSpawn*0.90f)
        {
            pos = playerPos
            + new Vector3(Random.Range(-distanceSpawn, distanceSpawn), Random.Range(-distanceSpawn, distanceSpawn), 0);
        }

        return pos;
    }
}

