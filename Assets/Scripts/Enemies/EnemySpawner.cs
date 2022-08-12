using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    using Misc;

    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private int waveAmount;
    
        //subject to change when we add enemy types
        [SerializeField] private EnemyData enemyData;
    
        private SpawnArea _spawnArea;
        private Transform _playerTransform;
        private ObjectPool<Enemy> _enemyPool;

        private void Awake()
        {
            GetReferences();
            CreateEnemyPool();
            SpawnNextEnemyWave();
        }

        private void GetReferences()
        {
            _spawnArea = gameObject.GetComponent<SpawnArea>();
            _playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
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
            enemy.Initialize(_playerTransform);
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
            var spawnLocation = _spawnArea.GetRandomPositionInSpawnArea(_playerTransform.position);
            enemy.ChangeAndApplyData(enemyData);
            enemy.Spawn(spawnLocation);
        }
    }
}
