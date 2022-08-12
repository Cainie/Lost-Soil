namespace Enemies
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public Sprite sprite;
        public int maxHealth;
        public int health;
        public int damage;
        public float speed;
        public float attackRange;
    }
}
