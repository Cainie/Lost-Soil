namespace ResourcesSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    
    public class ResourcesUIController : MonoBehaviour
    {
        [SerializeField] private List<ResourceUIController> resourceUIControllers;

        private void Awake()
        {
            resourceUIControllers.AddRange(GetComponentsInChildren<ResourceUIController>());
        }

        public void InitializeResourceUIControllers(List<ResourceData> resourcesData)
        {
            foreach (var resourceData in resourcesData)
            {
                var controller = GetSpecificResourceUIController(resourceData.resourceType);
                if (controller == null)
                {
                    throw new Exception("No specific controller for resource type: " + resourceData.resourceType);
                }
                
                controller.SetResourceSpriteAndName(resourceData.resourceSprite, resourceData.resourceName);
            }
        }

        public void ChangeResourceAmountDisplayed(StoredResourceDataModel resource)
        {
            var controller = GetSpecificResourceUIController(resource.resourceType);
            if (controller == null)
            {
                throw new Exception("No specific controller for resource type: " + resource.resourceType);
            }
            
            controller.ChangeResourceAmountDisplayed(resource.amount);
        }

        private ResourceUIController GetSpecificResourceUIController(ResourceType resourceType)
        {
            return resourceUIControllers.FirstOrDefault(x => x.GetResourceUIControllerResourceType() == resourceType);
        }
    }
}
