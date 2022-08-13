namespace EnemyWavesMechanic
{
    using System;
    using UnityEngine;
    
    [RequireComponent(typeof(WaveTimer),typeof(WaveTimerUI))]
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private WavesLenghtData wavesLenghtData;

        public event Action OnWaveTriggered;
        
        private WaveTimer _waveTimer;
        private WaveTimerUI _waveTimerUI;
        private int _nextWaveIndex;

        private const int LastWavesLenght = 90;

        private void Awake()
        {
            GetReferences();
            SubscribeToEvents();
            StartNextWaveCountdown();
        }

        private void GetReferences()
        {
            _waveTimer = gameObject.GetComponent<WaveTimer>();
            _waveTimerUI = gameObject.GetComponent<WaveTimerUI>();
        }

        private void SubscribeToEvents()
        {
            _waveTimer.OnTicked += WaveTimer_OnTicked;
            _waveTimer.OnTimerReachedZero += WaveTimer_OnTimerReachedZero;
        }

        private void StartNextWaveCountdown()
        {
            _waveTimer.SetTimer(_nextWaveIndex > wavesLenghtData.wavesLenght.Count
                ? wavesLenghtData.wavesLenght[LastWavesLenght]
                : wavesLenghtData.wavesLenght[_nextWaveIndex]);
        }

        private void WaveTimer_OnTicked(float time)
        {
            _waveTimerUI.DisplayTimer(time);
        }

        private void WaveTimer_OnTimerReachedZero()
        {
            _waveTimerUI.TimerReachedZero();
            OnWaveTriggered?.Invoke();
            _nextWaveIndex++;
            StartNextWaveCountdown();
        }
    }
}
