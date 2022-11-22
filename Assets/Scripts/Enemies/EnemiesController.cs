namespace Enemies
{
    using System;
    using System.Collections.Generic;
    using ResourcesSystem;
    using UnityEngine;
    using Random = UnityEngine.Random;

    public class EnemiesController : MonoBehaviour
    {
        public event Action<ResourceType, int> OnEnemyDeathResourcesGained;
        public event Action<EnemyType> OnEnemyKilledByPlayer;
        public event Action<EnemyType> OnEnemyDamagedByPlayer;
        public event Action<EnemyType> OnEnemyAttack;

        public void Enemy_OnEnemyKilledByPlayer(EnemyData enemyData)
        {
            EnemyKilledByPlayer(enemyData);
        }

        public void Enemy_OnEnemyDamagedByPlayer(EnemyData enemyData)
        {
            OnEnemyDamagedByPlayer?.Invoke(enemyData.enemyType);
        }

        public void Enemy_OnEnemyAttack(EnemyData enemyData)
        {
            OnEnemyAttack?.Invoke(enemyData.enemyType);
        }

        private void EnemyKilledByPlayer(EnemyData enemyData)
        {
            OnEnemyKilledByPlayer?.Invoke(enemyData.enemyType);
            if (!IsRandomResourceGained(enemyData.resourceDropChance)) return;
            var resourceGained = PickRandomDropResource(enemyData.availableResourcesUponKill);
            OnEnemyDeathResourcesGained?.Invoke(resourceGained.resourceType, resourceGained.resourceBasicAmount);
        }

        private bool IsRandomResourceGained(float resourceDropChance)
        {
            return Random.value < resourceDropChance;
        }

        private ResourceData PickRandomDropResource(List<ResourceData> availableResources)
        {
            return availableResources[Random.Range(0, availableResources.Count)];
        }
    }
}
