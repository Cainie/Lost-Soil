namespace SoundManager
{
    using System.Linq;
    using Enemies;
    using UnityEngine;
    
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource musicAudioSource;
        
        [SerializeField] private AudioSource soundsAudioSource;
        [SerializeField] private AudioSource playerMovementAudioSource;
        [SerializeField] private AudioSource playerSoundsAudioSource;
        [SerializeField] private AudioSource enemySoundsAudioSource;
        [SerializeField] private SoundsData soundsData;

        private bool _changeMoveSound;
        private const float PlayerMoveMaxPitch = 1.2f;
        private const float PlayerMoveMinPitch = 0.7f;

        public void PlaySound(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.BuildingBuiltSound:
                    PlaySound(soundsData.buildingBuiltSound);
                    break;
                case SoundType.ResourcePickedUpSound:
                    PlaySound(soundsData.resourcePickedUpSound);
                    break;
            }
        }

        public void PlayPlayerSound(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.PlayerMoveSound:
                    PlayPlayerMovementSound(soundsData.playerSoundsData.playerMoveSounds[0]);
                    break;
                case SoundType.PlayerWeaponSound:
                    PlayPlayerSound(soundsData.playerSoundsData.playerWeaponSound);
                    break;
                case SoundType.PlayerHitSound:
                    PlayPlayerSound(GetRandomSoundFromArray(soundsData.playerSoundsData.playerHitSounds));
                    break;
                case SoundType.PlayerDeathSound:
                    PlayPlayerSound(GetRandomSoundFromArray(soundsData.playerSoundsData.playerDeathSound));
                    break;
            }
        }

        public void PlayEnemySound(SoundType soundType, EnemyType enemyType)
        {
            var specificEnemyTypeSounds = GetEnemyTypeSoundsData(enemyType);
            switch (soundType)
            {
                case SoundType.EnemyHitSound:
                    PlayEnemySound(GetRandomSoundFromArray(specificEnemyTypeSounds.enemyHitSounds));
                    break;
                case SoundType.EnemyDeathSound:
                    PlayEnemySound(GetRandomSoundFromArray(specificEnemyTypeSounds.enemyDeathSounds));
                    break;
                case SoundType.EnemyAttackSound:
                    PlayEnemySound(GetRandomSoundFromArray(specificEnemyTypeSounds.enemyAttackSounds));
                    break;
            }
        }

        private void PlaySound(AudioClip soundToPlay)
        {
            soundsAudioSource.PlayOneShot(soundToPlay);
        }

        private void PlayPlayerSound(AudioClip soundToPlay)
        {
            playerSoundsAudioSource.PlayOneShot(soundToPlay);
        }

        private void PlayPlayerMovementSound(AudioClip soundToPlay)
        {
            if (!playerMovementAudioSource.isPlaying)
            {
                playerMovementAudioSource.pitch = GetRandomPitch();
                playerMovementAudioSource.PlayOneShot(soundToPlay);
            }
        }

        private void PlayEnemySound(AudioClip soundToPlay)
        {
            enemySoundsAudioSource.PlayOneShot(soundToPlay);
        }

        private AudioClip GetRandomSoundFromArray(AudioClip[] soundArray)
        {
            var randomIndex = Random.Range(0, soundArray.Length);
            return soundArray[randomIndex];
        }

        private AudioClip GetNextMovementSoundFromArray(AudioClip[] soundArray)
        {
            _changeMoveSound = !_changeMoveSound;
            var index = _changeMoveSound ? 0 : 1;

            return soundArray[index];
        }

        private float GetRandomPitch()
        {
            var randomPitch = Random.Range(PlayerMoveMinPitch,PlayerMoveMaxPitch);

            return randomPitch;
        }

        private EnemyTypeSoundsData GetEnemyTypeSoundsData(EnemyType enemyType)
        {
            return soundsData.enemiesSoundsData.FirstOrDefault(x => x.enemyType == enemyType);
        }
    }
}
