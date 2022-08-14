namespace GameController
{
    using Enemies;
    using EnemyWavesMechanic;
    using Misc;
    using Player;
    using ResourcesSystem;
    using SaveSystem;
    using UnityEngine;
    
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPosition;
        
        private GameState _gameState;
        
        private PlayerController _playerController;
        private SaveStateSystem _saveStateSystem;
        private ResourcesController _resourcesController;
        private EnemiesController _enemiesController;
        private WaveController _waveController;
        
        private void Awake()
        {
            GetReferences();
            SubscribeToEvents();
        }

        private void Start()
        {
            StartGame();
        }

        private void GetReferences()
        {
            _playerController = GameObject.FindGameObjectWithTag(Tags.PLAYER).gameObject.GetComponent<PlayerController>();
            _resourcesController = GameObject.FindGameObjectWithTag(Tags.RESOURCES_CONTROLLER).gameObject.GetComponent<ResourcesController>();
            _enemiesController = GameObject.FindGameObjectWithTag(Tags.ENEMIES_CONTROLLER).gameObject.GetComponent<EnemiesController>();
            _waveController = GameObject.FindGameObjectWithTag(Tags.WAVE_CONTROLLER).gameObject.GetComponent<WaveController>();
            _saveStateSystem = GameObject.FindGameObjectWithTag(Tags.SAVE_STATE_SYSTEM).gameObject.GetComponent<SaveStateSystem>();
        }

        private void SubscribeToEvents()
        {
            _playerController.OnResourcePickedUp += GainResource;
            _enemiesController.OnEnemyDeathResourcesGained += GainResource;
        }

        private void StartGame()
        {
            if (IsNewGame())
            {
                StartNewGame();
            } else
            {
                LoadState();
            }
        }
        
        public void SaveState()
        {
            PrepareGameState();
            _saveStateSystem.SaveState(_gameState);
        }
        
        public void LoadState()
        {
            _gameState = _saveStateSystem.LoadState();
            _playerController.ResetPlayerPosition(_gameState.position);
            _playerController.DistributePlayerLoadedData(_gameState.health);
            _resourcesController.SetResourceStorage(_gameState.resourcesStorage);
            _waveController.StartWaves(_gameState.waveIndex);
        }

        private bool IsNewGame()
        {
#if UNITY_EDITOR
            //for testing purpose
            return true;
#endif
            return GlobalVariables.isNewGame;
        }
        
        private void StartNewGame()
        {
            _gameState = new GameState();
            _playerController.ResetPlayerPosition(_gameState.position);
            _playerController.DistributePlayerData();
            _resourcesController.InitializeResourceStorageController();
            _waveController.StartWaves(0);
        }

        private void GainResource(ResourceType resourceType, int resourceAmount)
        {
            _resourcesController.GainResource(resourceType, resourceAmount);
        }

        private void UseResource(ResourceType resourceType, int resourceAmount)
        {
            _resourcesController.UseResource(resourceType,resourceAmount);
        }

        private void PrepareGameState()
        {
            _gameState.health = _playerController.GetPlayerHealth();
            _gameState.position = playerSpawnPosition.position;
            _gameState.waveIndex = _waveController.GetWaveIndex();
            _gameState.resourcesStorage = _resourcesController.GetResourceStorage();
        }
    }
}
