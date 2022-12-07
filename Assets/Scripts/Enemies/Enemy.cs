namespace Enemies
{
    using System;
    using UnityEngine;
    using Misc;
    using Player;

    public abstract class Enemy : MonoBehaviour
    {
        private EnemyData _data;
        private EnemyInternalData _enemyInternalData;
        private Transform _playerLocation;
        private SpriteRenderer _spriteRenderer;
        private EnemiesController _enemiesController;
        private int _currentHealth;
        private Vector2 _moveWaypoint;
        private float _waypointFocusTimer;
        private bool _isInitialized;

        public event Action<EnemyData> OnEnemyKilledByPlayer;
        public event Action<Enemy> OnEnemyKilled;
        public event Action<EnemyData> OnEnemyDamagedByPlayer;
        public event Action<EnemyData> OnEnemyAttack;
        
        private void FixedUpdate()
        {
            if (!_isInitialized) return;

            if (!IsPlayerNearby()) return;

            _waypointFocusTimer -= Time.unscaledDeltaTime;
            if (_waypointFocusTimer <= 0)
            {
                SetNewWaypoint();
                _waypointFocusTimer = _data.waypointFocusTime;
            }
            
            Move();
        }

        public void Initialize(Transform playerLocation)
        {
            _playerLocation = playerLocation;
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _isInitialized = true;
        }

        public void ChangeAndApplyData(EnemyData data)
        {
            _data = data;
            ApplyData();
        }

        public void Spawn(Vector2 spawnLocation)
        {
            transform.position = spawnLocation;
        }

        public void ResetEnemy()
        {
        
        }

        private void ApplyData()
        {
            _currentHealth = _data.maxHealth;
            _spriteRenderer.sprite = _data.sprite;
        }

        private bool IsPlayerNearby()
        {
            var distanceToPlayer = Vector2.Distance(_playerLocation.position, transform.position);
            return distanceToPlayer <= _data.aggroRange;
        }

        private void SetNewWaypoint()
        {
            //var waypoint = new Vector2(_playerLocation.position.x,_playerLocation.position.y);
            _moveWaypoint = _playerLocation.position;
        }

        private void Move()
        {
            var step = _data.speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _moveWaypoint, step);
        }

        public void TakeDamage(int damageTaken)
        {
            _currentHealth -= damageTaken;
            if (_currentHealth <= 0)
            {
                Die();
            } 
            else
            {
                OnEnemyDamagedByPlayer?.Invoke(_data);
            }
        }

        private void Die()
        {
            OnEnemyKilledByPlayer?.Invoke(_data);
            OnEnemyKilled?.Invoke(this);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER)) return;
            var playerController = other.GetComponent<PlayerController>();
            playerController.ReceiveAttack(_data.damage);
            OnEnemyAttack?.Invoke(_data);
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            if (!_isInitialized)
                return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,_data.aggroRange);
        }
    }
}
