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

        public void Enemy_OnEnemyKilledByPlayer(EnemyData enemyData)
        {
            EnemyKilledByPlayer(enemyData);
        }

        private void EnemyKilledByPlayer(EnemyData enemyData)
        {
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
