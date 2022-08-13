namespace ResourcesSystem
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class ResourceUIController : MonoBehaviour
    {
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private TextMeshProUGUI resourceName;
        [SerializeField] private Image resourceImage;
        [SerializeField] private TextMeshProUGUI resourceAmount;

        public void SetResourceSpriteAndName(Sprite sprite, string name)
        {
            resourceImage.sprite = sprite;
            resourceName.text = name;
        }

        public ResourceType GetResourceUIControllerResourceType()
        {
            return resourceType;
        }
        
        public void ChangeResourceAmountDisplayed(int newResourceAmount)
        {
            resourceAmount.text = newResourceAmount.ToString();
        }
        
    }
}
