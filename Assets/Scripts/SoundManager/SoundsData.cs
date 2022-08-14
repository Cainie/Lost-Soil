namespace SoundManager
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "Sounds/SoundsData")]
    public class SoundsData : ScriptableObject
    {
        public AudioClip[] gameMusicClipsArray = new AudioClip[0];

        public PlayerSoundsData playerSoundsData;
        public List<EnemyTypeSoundsData> enemiesSoundsData;
        public List<WeaponTypeSoundData> weaponsSoundsData;
        public AudioClip buildingBuiltSound;
        public AudioClip resourcePickedUpSound;
    }
}
