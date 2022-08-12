using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class SpawnArea : MonoBehaviour
    {
        [SerializeField] private float minDistanceToPlayer;
        [SerializeField] private Vector2 spawnAreaSize;

        private Vector2 randomPosition;
        private const int maxAwayFromPlayerLocationGenerationAttempts = 50;
    
        public Vector2 GetRandomPositionInSpawnArea(Vector2 playerPosition)
        {
            for (var i = 0; i < maxAwayFromPlayerLocationGenerationAttempts; i++)
            {
                randomPosition = GenerateRandomPositionInSpawnArea();
                var distanceToPlayer = Vector2.Distance(playerPosition, randomPosition);
                if (distanceToPlayer > minDistanceToPlayer)
                {
                    break;
                }
            }

            if (RandomLocationNearPlayerAnyway(playerPosition))
            {
                throw new Exception("Enemy location too close to player");
            }
            return randomPosition;
        }

        private Vector2 GenerateRandomPositionInSpawnArea()
        {
            var randomXPosition = Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2);
            var randomYPosition = Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2);
            return (Vector2)transform.localPosition + new Vector2(randomXPosition, randomYPosition);
        }

        private bool RandomLocationNearPlayerAnyway(Vector2 playerPosition)
        {
            var distanceToPlayer = Vector2.Distance(playerPosition, randomPosition);
            return distanceToPlayer < minDistanceToPlayer;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.localPosition,spawnAreaSize);
        }
    }
}
