namespace SaveSystem
{
    using System;
    using System.Collections.Generic;
    using ResourcesSystem;
    using UnityEngine;
    
    [Serializable]
    public class GameState
    {
        public Vector2 position;
        public int health;
        public int waveIndex;
        public List<StoredResourceDataModel> resourcesStorage;

    }
}