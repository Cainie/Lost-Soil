namespace Enemies
{
    using UnityEngine;
    using Misc;
    using Player;

    public abstract class Enemy : MonoBehaviour
    {
        private EnemyData _data;
        private Transform _playerLocation;
        private SpriteRenderer _spriteRenderer;

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
            _data.health = _data.maxHealth;
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
            _data.health -= damageTaken;
        }

        private void Die()
        {
        
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER)) return;
            var playerController = other.GetComponent<PlayerController>();
            playerController.ReceiveAttack(_data.damage);
            Destroy(gameObject);
        }
    }
}
