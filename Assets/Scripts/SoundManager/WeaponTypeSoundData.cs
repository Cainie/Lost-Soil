namespace SoundManager
{
    using UnityEngine;
    using Weapons;

    [CreateAssetMenu(menuName = "Sounds/WeaponTypeSoundData")]
    public class WeaponTypeSoundData : ScriptableObject
    {
        public WeaponType weaponType;
        public AudioClip weaponShootSound;
    }
}
