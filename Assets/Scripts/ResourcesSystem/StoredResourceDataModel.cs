namespace ResourcesSystem
{
    public class StoredResourceDataModel
    {
        public StoredResourceDataModel(ResourceType resourceType, int amount)
        {
            this.resourceType = resourceType;
            this.amount = amount;
        }

        public ResourceType resourceType;
        public int amount;
    }
}
