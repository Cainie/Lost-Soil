using UnityEngine;
using UnityEngine.Pool;

namespace Enemies
{
    using EnemyWavesMechanic;
    using Misc;

    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private int waveAmount;
    
        //subject to change when we add enemy types
        [SerializeField] private EnemyData enemyData;
    
        private SpawnArea _spawnArea;
        private Transform _playerTransform;
        private WaveController _waveController;
        private EnemiesController _enemiesController;
        
        private ObjectPool<Enemy> _enemyPool;

        private void Awake()
        {
            GetReferences();
            CreateEnemyPool();
            SubscribeToEvents();
        }

        private void GetReferences()
        {
            _spawnArea = gameObject.GetComponent<SpawnArea>();
            _enemiesController = gameObject.GetComponent<EnemiesController>();
            _playerTransform = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
            _waveController = GameObject.FindGameObjectWithTag(Tags.WAVE_CONTROLLER).gameObject.GetComponent<WaveController>();
        }

        private void SubscribeToEvents()
        {
            _waveController.OnWaveTriggered += SpawnNextEnemyWave;
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
            enemy.OnEnemyKilledByPlayer += _enemiesController.Enemy_OnEnemyKilledByPlayer;
            enemy.OnEnemyDamagedByPlayer += _enemiesController.Enemy_OnEnemyDamagedByPlayer;
            enemy.OnEnemyDamagedByPlayer += _enemiesController.Enemy_OnEnemyAttack;
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
