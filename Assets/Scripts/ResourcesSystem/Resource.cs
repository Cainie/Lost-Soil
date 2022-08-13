namespace ResourcesSystem
{
    using Misc;
    using Player;
    using UnityEngine;

    public class Resource : MonoBehaviour
    {
        [SerializeField] private ResourceData resourceData;

        private void Awake()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = resourceData.resourceSprite;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(Tags.PLAYER)) return;
            var playerController = other.GetComponent<PlayerController>();
            playerController.GainResource(resourceData.resourceType,resourceData.resourceBasicAmount);
            ResourcePickedUpAnimation();
            Destroy(gameObject);
        }

        private void ResourcePickedUpAnimation()
        {
            
        }
    }
}
