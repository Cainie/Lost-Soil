namespace Player
{
    using System;
    using ResourcesSystem;
    using UnityEngine;
    
    [RequireComponent(typeof(PlayerHealthController),typeof(PlayerSpriteController),typeof(PlayerMovementController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        public event Action<ResourceType, int> OnResourcePickedUp;

        private PlayerHealthController _playerHealthController;
        private PlayerSpriteController _playerSpriteController;
        private PlayerMovementController _playerMovementController;

        private void Awake()
        {
            SetReferences();
            DistributePlayerData();
            SubscribeToEvents();
        }
        
        public void ReceiveAttack(int attackAmount)
        {
            _playerHealthController.ReceiveAttack(attackAmount);
        }

        public void GainResource(ResourceType resourceType, int resourceAmount)
        {
            OnResourcePickedUp?.Invoke(resourceType, resourceAmount);
        }

        private void SetReferences()
        {
            _playerHealthController = gameObject.GetComponent<PlayerHealthController>();
            _playerSpriteController = gameObject.GetComponent<PlayerSpriteController>();
            _playerMovementController = gameObject.GetComponent<PlayerMovementController>();
        }

        private void DistributePlayerData()
        {
            _playerHealthController.SetPlayerData(playerData);
            _playerSpriteController.SetPlayerData(playerData);
            _playerMovementController.SetPlayerData(playerData);
        }

        private void SubscribeToEvents()
        {
            _playerHealthController.OnPlayerDeath += PlayerHealthController_OnPlayerDeath;
            _playerHealthController.OnPlayerDamaged += PlayerHealthController_OnPlayerDamaged;
        }

        private void PlayerHealthController_OnPlayerDeath()
        {
            Die();
        }

        private void Die()
        {
            Debug.Log("You died~~");
            Debug.Log("Ba dum tss~~");
        }
        
        private void PlayerHealthController_OnPlayerDamaged()
        {
            _playerSpriteController.PlayerDamaged();
        }
    }
}
