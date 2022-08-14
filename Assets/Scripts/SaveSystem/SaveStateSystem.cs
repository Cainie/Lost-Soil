namespace SaveSystem
{
    using System.IO;
    using Sirenix.Serialization;
    using UnityEngine;
    
    public class SaveStateSystem : MonoBehaviour
    {
        private const string FilePathEnding = "/player.save";
        private string _filePath;

        private void Awake()
        {
            _filePath = Application.persistentDataPath + FilePathEnding;
        }

        public void SaveState(GameState gameState)
        {
            var bytes = SerializationUtility.SerializeValue(gameState, DataFormat.Binary);
            File.WriteAllBytes(_filePath,bytes);
        }

        public GameState LoadState()
        {
            if (!File.Exists(_filePath)) {Debug.Log("No file found in path: " + _filePath);}
            var bytes = File.ReadAllBytes(_filePath);
            return SerializationUtility.DeserializeValue<GameState>(bytes, DataFormat.Binary);
        }
    }
}
