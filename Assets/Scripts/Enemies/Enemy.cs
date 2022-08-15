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

        public event Action<EnemyData> OnEnemyKilledByPlayer;
        public event Action<Enemy> OnEnemyKilled;
        public event Action<EnemyData> OnEnemyDamagedByPlayer;
        public event Action<EnemyData> OnEnemyAttack;
        
        private void FixedUpdate()
        {
            if (isActiveAndEnabled)
            {
                Move();
            }
        }

        public void Initialize(Transform playerLocation)
        {
            _playerLocation = playerLocation;
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void ChangeAndApplyData(EnemyData data)
        {
            _data = data;
            ApplyData();
        }

        private void ApplyData()
        {
            _currentHealth = _data.maxHealth;
            _spriteRenderer.sprite = _data.sprite;
        }

        public void Spawn(Vector2 spawnLocation)
        {
            transform.position = spawnLocation;
        }

        public void ResetEnemy()
        {
        
        }

        private void Move()
        {
            var step = _data.speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _playerLocation.position, step);
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
    }
}
