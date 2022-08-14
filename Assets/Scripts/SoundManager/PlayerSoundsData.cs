namespace SoundManager
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "Sounds/PlayerSounds")]
    public class PlayerSoundsData : ScriptableObject
    {
        public AudioClip[] playerMoveSounds;
        public AudioClip playerWeaponSound;
        public AudioClip[] playerHitSounds;
        public AudioClip[] playerDeathSound;
    }
}
