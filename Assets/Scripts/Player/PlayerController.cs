namespace Player
{
    using System;
    using EnemyWavesMechanic;
    using Misc;
    using ResourcesSystem;
    using UnityEngine;
    
    [RequireComponent(typeof(PlayerHealthController),typeof(PlayerSpriteController),typeof(PlayerMovementController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;

        public event Action<ResourceType, int> OnResourcePickedUp;

        private PlayerSpriteController _playerSpriteController;
        private PlayerMovementController _playerMovementController;
        private PlayerHealthController _playerHealthController;
        private PlayerHealthUIController _playerHealthUIController;

        private void Awake()
        {
            SetReferences();
            DistributePlayerData();
            SubscribeToEvents();
            SetPlayerStartingHealth();
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
            _playerHealthUIController = GameObject.FindGameObjectWithTag(Tags.PLAYER_HEALTH_UI_CONTROLLER).gameObject.GetComponent<PlayerHealthUIController>();
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

        /* 
        private void Die()
        {
            Debug.Log("You died~~");
            Debug.Log("Ba dum tss~~");

        }
       */

        private void SetPlayerStartingHealth()
        {
            _playerHealthUIController.SetHealthAmountText(playerData.health);
        }
        
        private void PlayerHealthController_OnPlayerDamaged()
        {
            _playerSpriteController.PlayerDamaged();
            _playerHealthUIController.ChangeHealthUIFill(playerData.health, playerData.maxHealth);
            _playerHealthUIController.SetHealthAmountText(playerData.health);
        }


        //Maciek

        public GameObject DeathScript;
        private void Die()
        {            
            DeathScript.GetComponent<DeathScreen>().Death();
        }



    }
}
