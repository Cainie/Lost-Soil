namespace ResourcesSystem
{
    using System.Collections.Generic;
    using UnityEngine;
    
    [RequireComponent(typeof(ResourcesStorageController),typeof(ResourcesUIController))]
    public class ResourcesController : MonoBehaviour
    {
        [SerializeField] private List<ResourceData> resourcesData;
        private ResourcesUIController _resourcesUIController;
        private ResourcesStorageController _resourcesStorageController;

        private void Awake()
        {
            GetReferences();
            InitializeResourcesStorage();
            SubscribeToEvents();
        }

        private void Start()
        {
            _resourcesUIController.InitializeResourceUIControllers(resourcesData);
        }

        public void GainResource(ResourceType resourceType, int resourceAmount)
        {
            _resourcesStorageController.StoreResource(resourceType,resourceAmount);
        }

        public void UseResource(ResourceType resourceType, int resourceAmount)
        {
            _resourcesStorageController.UseResource(resourceType,resourceAmount);
        }

        private void GetReferences()
        {
            _resourcesUIController = gameObject.GetComponent<ResourcesUIController>();
            _resourcesStorageController = gameObject.GetComponent<ResourcesStorageController>();
        }

        private void InitializeResourcesStorage()
        {
            _resourcesStorageController.InitializeResourcesStorage(resourcesData);
        }

        private void SubscribeToEvents()
        {
            _resourcesStorageController.OnResourceAmountChanged += ResourcesStorageController_OnResourceAmountChanged;
        }
        
        private void ResourcesStorageController_OnResourceAmountChanged(StoredResourceDataModel resource)
        {
            _resourcesUIController.ChangeResourceAmountDisplayed(resource);
        }
    }
}
