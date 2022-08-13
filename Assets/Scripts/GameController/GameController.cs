namespace GameController
{
    using Misc;
    using ResourcesSystem;
    using UnityEngine;
    
    public class GameController : MonoBehaviour
    {
        private ResourcesController _resourcesController;
        
        private void Awake()
        {
            GetReferences();
        }

        private void GetReferences()
        {
            _resourcesController = GameObject.FindGameObjectWithTag(Tags.RESOURCES_CONTROLLER).gameObject.GetComponent<ResourcesController>();
        }

        public void GainResource(ResourceType resourceType, int resourceAmount)
        {
            _resourcesController.GainResource(resourceType,resourceAmount);
        }

        private void UseResource(ResourceType resourceType, int resourceAmount)
        {
            _resourcesController.UseResource(resourceType,resourceAmount);
        }
    }
}
