namespace SoundManager
{
    using UnityEngine;
    
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource soundsAudioSource;
        [SerializeField] private SoundsData soundsData;
        
        
        
        public void PlaySound(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.PlayerMoveSound:
                    PlaySound(soundsData.playerMoveSound);
                    break;
                case SoundType.PlayerWeaponSound:
                    PlaySound(soundsData.playerWeaponSound);
                    break;
                case SoundType.PlayerHitSound:
                    PlaySound(soundsData.playerHitSound);
                    break;
                case SoundType.PlayerDeathSound:
                    PlaySound(soundsData.playerDeathSound);
                    break;
                case SoundType.EnemyHitSound:
                    PlaySound(soundsData.enemyHitSound);
                    break;
                case SoundType.EnemyDeathSound:
                    PlaySound(soundsData.enemyDeathSound);
                    break;
                case SoundType.EnemyAttackedSound:
                    PlaySound(soundsData.enemyAttackedSound);
                    break;
                case SoundType.BuildingBuiltSound:
                    PlaySound(soundsData.buildingBuiltSound);
                    break;
                case SoundType.ResourcePickedUpSound:
                    PlaySound(soundsData.resourcePickedUpSound);
                    break;
                default:
                    break;
            }
        }

        private void PlaySound(AudioClip soundToPlay)
        {
            soundsAudioSource.PlayOneShot(soundToPlay);
        }
    }
}
