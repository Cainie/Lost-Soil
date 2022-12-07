namespace Enemies
{
    using System.Collections.Generic;
    using ResourcesSystem;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public Sprite sprite;
        public EnemyType enemyType;
        public int maxHealth;
        public int damage;
        public float speed;
        public float aggroRange;
        public float waypointFocusTime;
        public List<ResourceData> availableResourcesUponKill;
        [Range(0.0f,1.0f)]
        public float resourceDropChance;
    }
}
