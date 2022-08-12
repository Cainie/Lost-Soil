using System;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private SpawnArea spawnArea;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int waveAmount;
    
    //subject to change when we add enemy types
    [SerializeField] private EnemyData enemyData;
    
    private ObjectPool<Enemy> _enemyPool;

    private void Awake()
    {
        CreateEnemyPool();
        SpawnNextEnemyWave();
    }

    private void CreateEnemyPool()
    {
        _enemyPool = new ObjectPool<Enemy>(CreateEnemy,
            enemy => { enemy.gameObject.SetActive(true); },
            enemy => { enemy.gameObject.SetActive(false);},
            enemy => Destroy(enemy.gameObject),
            false);
    }
    
    private Enemy CreateEnemy()
    {
        var enemy = Instantiate(enemyPrefab);
        enemy.Initialize(playerTransform);
        return enemy;
        
    }
    
    private void SpawnNextEnemyWave()
    {
        for (var i = 0; i < waveAmount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = _enemyPool.Get();
        var spawnLocation = spawnArea.GetRandomPositionInSpawnArea(playerTransform.position);
        enemy.ChangeAndApplyData(enemyData);
        enemy.Spawn(spawnLocation);
    }
}
