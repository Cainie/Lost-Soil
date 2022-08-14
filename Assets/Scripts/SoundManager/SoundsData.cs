namespace SoundManager
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "SoundsData")]
    public class SoundsData : ScriptableObject
    {
        public AudioClip[] gameMusicClipsArray = new AudioClip[0];
        
        public AudioClip playerMoveSound;
        public AudioClip playerWeaponSound;
        public AudioClip playerHitSound;
        public AudioClip playerDeathSound;
        public AudioClip enemyHitSound;
        public AudioClip enemyDeathSound;
        public AudioClip enemyAttackedSound;
        public AudioClip buildingBuiltSound;
        public AudioClip resourcePickedUpSound;
    }
}
