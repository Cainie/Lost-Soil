namespace ResourcesSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class ResourcesStorageController : MonoBehaviour
    {
        public event Action<StoredResourceDataModel> OnResourceAmountChanged;
        private List<StoredResourceDataModel> _resourcesStorage;

        public void InitializeResourcesStorage(List<ResourceData> resourcesData)
        {
            _resourcesStorage = new List<StoredResourceDataModel>();
            foreach (var resourceData in resourcesData)
            {
                _resourcesStorage.Add(new StoredResourceDataModel(resourceData.resourceType,0));
            }
        }

        public void StoreResource(ResourceType resourceType, int resourceAmount)
        {
            var index = _resourcesStorage.FindIndex(x => x.resourceType == resourceType);
            if (index >= 0)
            {
                _resourcesStorage[index].amount += resourceAmount;
                OnResourceAmountChanged?.Invoke(_resourcesStorage[index]);
            } 
            else
            {
                throw new Exception("No such resource in storage");
            }
        }

        public void UseResource(ResourceType resourceType, int resourceAmount)
        {
            var index = _resourcesStorage.FindIndex(x => x.resourceType == resourceType);
            if (index >= 0)
            {
                _resourcesStorage[index].amount -= resourceAmount;
                OnResourceAmountChanged?.Invoke(_resourcesStorage[index]);
            } 
            else
            {
                throw new Exception("No such resource in storage");
            }
        }

        public int GetStoredResourceAmount(ResourceType resourceType)
        {
            var resourceAmount = _resourcesStorage.FirstOrDefault(x => x.resourceType == resourceType).amount;
            return resourceAmount;
        }
    }
}
