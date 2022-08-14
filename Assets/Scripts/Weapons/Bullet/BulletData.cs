namespace Weapons.Bullet
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "Weapon/BulletData")]
    public class BulletData : ScriptableObject
    {
        public int bulletDamage;
        public float bulletSpeed;
    }
}
