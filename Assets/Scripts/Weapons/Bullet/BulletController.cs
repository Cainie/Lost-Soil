namespace Weapons.Bullet
{
    using System;
    using Enemies;
    using Misc;
    using UnityEngine;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private BulletData bulletData;
        private Rigidbody2D _bulletRigidbody2D;

        private void Awake()
        {
            _bulletRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        public void ShootBullet()
        {
            _bulletRigidbody2D.velocity = transform.right * bulletData.bulletSpeed;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(Tags.ENEMY)) return;
            var enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(bulletData.bulletDamage);
            BulletHitEffect();
            Destroy(gameObject);
        }

        private void BulletHitEffect()
        {
            //maybe later some more feedback
        }
    }
}
