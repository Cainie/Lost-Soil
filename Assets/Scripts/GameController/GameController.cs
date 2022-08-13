namespace GameController
{
    using System;
    using Enemies;
    using EnemyWavesMechanic;
    using Misc;
    using Player;
    using ResourcesSystem;
    using UnityEngine;
    
    public class GameController : MonoBehaviour
    {
        private PlayerController _playerController;
        private ResourcesController _resourcesController;
        private EnemiesController _enemiesController;
        private WaveController _waveController;
        
        private void Awake()
        {
            GetReferences();
            SubscribeToEvents();
        }

        private void GetReferences()
        {
            _playerController = GameObject.FindGameObjectWithTag(Tags.PLAYER).gameObject.GetComponent<PlayerController>();
            _resourcesController = GameObject.FindGameObjectWithTag(Tags.RESOURCES_CONTROLLER).gameObject.GetComponent<ResourcesController>();
            _enemiesController = GameObject.FindGameObjectWithTag(Tags.ENEMIES_CONTROLLER).gameObject.GetComponent<EnemiesController>();
            _waveController = GameObject.FindGameObjectWithTag(Tags.WAVE_CONTROLLER).gameObject.GetComponent<WaveController>();
        }

        private void SubscribeToEvents()
        {
            _playerController.OnResourcePickedUp += GainResource;
            _enemiesController.OnEnemyDeathResourcesGained += GainResource;
        }

        private void GainResource(ResourceType resourceType, int resourceAmount)
        {
            _resourcesController.GainResource(resourceType, resourceAmount);
        }

        private void UseResource(ResourceType resourceType, int resourceAmount)
        {
            _resourcesController.UseResource(resourceType,resourceAmount);
        }
        
        
    }
}
