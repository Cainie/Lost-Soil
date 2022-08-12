namespace Player
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public int health;
        public int maxHealth;
        public float moveSpeed;

        public Sprite sprite;
        
        public Color invulnerabilityColor;
        public float invulnerabilityDurationInSeconds;
        public float invulnerabilityDeltaTime;
    }
}
