namespace SoundManager
{
    using UnityEngine;
    using Enemies;

    [CreateAssetMenu(menuName = "Sounds/EnemyTypeSoundsData")]
    public class EnemyTypeSoundsData : ScriptableObject
    {
        public EnemyType enemyType;
        public AudioClip[] enemyHitSounds;
        public AudioClip[] enemyDeathSounds;
        public AudioClip[] enemyAttackSounds;
    }
}
