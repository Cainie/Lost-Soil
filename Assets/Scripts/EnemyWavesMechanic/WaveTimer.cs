namespace EnemyWavesMechanic
{
    using System;
    using UnityEngine;
    
    public class WaveTimer : MonoBehaviour
    {

        public event Action<float> OnTicked;
        public event Action OnTimerReachedZero;

        private float _timeRemaining;
        private bool _timerIsRunning;
        
        public void SetTimer(int time)
        {
            _timeRemaining = time;
            _timerIsRunning = true;
        }

        private void Update()
        {
            if (!_timerIsRunning) return;
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                OnTicked?.Invoke(_timeRemaining);
            }
            else
            {
                _timerIsRunning = false;
                OnTimerReachedZero?.Invoke();
            }
        }
    }
}
