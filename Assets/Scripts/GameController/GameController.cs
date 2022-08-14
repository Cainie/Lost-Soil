namespace GameController
{
    using Enemies;
    using EnemyWavesMechanic;
    using Misc;
    using Player;
    using ResourcesSystem;
    using SoundManager;
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
        private SoundManager _soundManager;
        
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
            _soundManager = GameObject.FindGameObjectWithTag(Tags.SOUND_MANAGER).gameObject.GetComponent<SoundManager>();
            _saveStateSystem = GameObject.FindGameObjectWithTag(Tags.SAVE_STATE_SYSTEM).gameObject.GetComponent<SaveStateSystem>();
        }

        private void SubscribeToEvents()
        {
            _playerController.OnResourcePickedUp += PlayerController_OnResourcePickedUp;
            _playerController.OnPlayerDeath += PlayerController_OnPlayerDeath;
            _playerController.OnPlayerDamaged += PlayerController_OnPlayerDamaged;
            _playerController.OnPlayerMove += PlayerController_OnPlayerMove;
            _enemiesController.OnEnemyDeathResourcesGained += GainResource;
            _enemiesController.OnEnemyKilledByPlayer += EnemyController_OnEnemyKilledByPlayer;
            _enemiesController.OnEnemyDamagedByPlayer += EnemyController_OnEnemyDamagedByPlayer;
            _enemiesController.OnEnemyAttack += EnemyController_OnEnemyAttack;
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

        private void PlaySound(SoundType soundType)
        {
            _soundManager.PlaySound(soundType);
        }

        private void PlayPlayerSound(SoundType soundType)
        {
            _soundManager.PlayPlayerSound(soundType);
        }

        private void PlayEnemySound(SoundType soundType, EnemyType enemyType)
        {
            _soundManager.PlayEnemySound(soundType, enemyType);
        }

        private void PlayerController_OnResourcePickedUp(ResourceType resourceType, int resourceAmount)
        {
            GainResource(resourceType,resourceAmount);
            PlaySound(SoundType.ResourcePickedUpSound);
        }

        private void PlayerController_OnPlayerDeath()
        {
            PlayPlayerSound(SoundType.PlayerDeathSound);
        }

        private void PlayerController_OnPlayerDamaged()
        {
            PlayPlayerSound(SoundType.PlayerHitSound);
        }

        private void PlayerController_OnPlayerMove()
        {
            PlayPlayerSound(SoundType.PlayerMoveSound);
        }

        private void EnemyController_OnEnemyKilledByPlayer(EnemyType enemyType)
        {
            PlayEnemySound(SoundType.EnemyDeathSound, enemyType);
        }
        
        private void EnemyController_OnEnemyDamagedByPlayer(EnemyType enemyType)
        {
            PlayEnemySound(SoundType.EnemyHitSound, enemyType);
        }
        
        private void EnemyController_OnEnemyAttack(EnemyType enemyType)
        {
            PlayEnemySound(SoundType.EnemyAttackSound, enemyType);
        }
    }
}
