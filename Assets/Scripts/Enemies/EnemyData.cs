namespace Enemies
{
    using System.Collections.Generic;
    using ResourcesSystem;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public Sprite sprite;
        public int maxHealth;
        public int health;
        public int damage;
        public float speed;
        public List<ResourceData> availableResourcesUponKill;
        [Range(0.0f,1.0f)]
        public float resourceDropChance;
    }
}
