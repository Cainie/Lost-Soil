namespace Weapons
{
    using System;
    using UnityEngine;
    
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform firePoint; 
        [SerializeField]private WeaponData weaponData;
        
        public event Action<WeaponType> OnWeaponShot;
        
        private float _weaponCooldownTimeStamp;


        public void TryShoot()
        {
            if (!IsWeaponOffCooldown()) { return; }

            Shoot();
            AddCooldownPeriod();
        }
        
        private bool IsWeaponOffCooldown()
        {
            return _weaponCooldownTimeStamp <= Time.time;
        }
        
        private void Shoot()
        {
            var bulletObject = Instantiate(weaponData.bulletPrefab, firePoint.position, firePoint.rotation);
            var bulletController = bulletObject.gameObject.GetComponent<Bullet.BulletController>();
            bulletController.ShootBullet();
            OnWeaponShot?.Invoke(weaponData.weaponType);
        }

        private void AddCooldownPeriod()
        {
            _weaponCooldownTimeStamp = Time.time + weaponData.cooldown;
        }
        
    }
}
