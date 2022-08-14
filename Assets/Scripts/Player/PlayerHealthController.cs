namespace Player
{
    using UnityEngine;
    using System;
    using System.Collections;

    public class PlayerHealthController : MonoBehaviour
    {
        public event Action OnPlayerDeath;
        public event Action OnPlayerDamaged;
        public event Action OnPlayerHealthValueLoaded;

        private PlayerData _playerData;
        private bool _isInvulnerable;
        private TimeSpan _lastInvulnerableFrameSpan;

        public void SetPlayerData(PlayerData playerData)
        {            _playerData = playerData;
            _playerData.health = _playerData.maxHealth;
            OnPlayerHealthValueLoaded?.Invoke();
        }

        public void LoadPlayerHealthValue(int healthValue)
        {
            _playerData.health = healthValue;
            OnPlayerHealthValueLoaded?.Invoke();
        }

        public void ReceiveAttack(int attackAmount)
        {
            if (_isInvulnerable) { return; }

            ProcessAttack(attackAmount);
        }

        private void ProcessAttack(int attackAmount)
        {
            ReceiveDamage(attackAmount);
            TriggerInvulnerability();
            CheckHealthStatus();
        }

        private void ReceiveDamage(int attackAmount)
        {
            _playerData.health -= attackAmount;
            OnPlayerDamaged?.Invoke();
        }

        private void TriggerInvulnerability()
        {
            StartCoroutine(BecomeInvulnerable());
        }

        private IEnumerator BecomeInvulnerable()
        {
            _isInvulnerable = true;

            yield return new WaitForSeconds(_playerData.invulnerabilityDurationInSeconds);

            _isInvulnerable = false;
        }

        private void CheckHealthStatus()
        {
            if (_playerData.health < 0)
            {
                OnPlayerDeath?.Invoke();
            }
        }

    }  


}
