namespace EnemyWavesMechanic
{
    using System.Collections.Generic;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "WavesLenghtData")]
    public class WavesLenghtData : ScriptableObject
    {
        public List<int> wavesLenght;
    }
}
