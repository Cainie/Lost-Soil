namespace Weapons
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "Weapon/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public WeaponType weaponType;
        public float cooldown;
        public GameObject bulletPrefab;
    }
}
