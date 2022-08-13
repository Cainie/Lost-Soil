namespace ResourcesSystem
{
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "ResourceData")]
    public class ResourceData : ScriptableObject
    {
        public string resourceName;
        public ResourceType resourceType;
        public Sprite resourceSprite;
        public int resourceBasicAmount;
    }

    public enum ResourceType
    {
        Wood,
        Stone,
        Food,
        Energy
    }
}
