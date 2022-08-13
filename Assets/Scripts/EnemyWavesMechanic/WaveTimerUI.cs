namespace EnemyWavesMechanic
{
    using System.Collections;
    using TMPro;
    using UnityEngine;
    
    public class WaveTimerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI waveTimer;
        [SerializeField] private RectTransform shakeMechanicRectTransform;

        private const float ShakeStrength = 5f;
        private const float ShakeDurationInSeconds = 2.0f;
        private const float ShakeDeltaTime = 0.02f;

        private bool _isShaking;

        public void DisplayTimer(float time)
        {
            if(_isShaking){return;}

            time += 1;
            float minutes = Mathf.FloorToInt(time / 60); 
            float seconds = Mathf.FloorToInt(time % 60);
            
            waveTimer.text = $"{minutes:00}:{seconds:00}";
        }

        public void TimerReachedZero()
        {
            ShakeTimer();
        }

        private void ShakeTimer()
        {
            StartCoroutine(StartShaking());
        }

        private IEnumerator StartShaking()
        {
            _isShaking = true;
            
            for (float i = 0; i < ShakeDurationInSeconds; i+= ShakeDeltaTime)
            {
                shakeMechanicRectTransform.anchoredPosition = GetRandomOffsetPosition();

                yield return new WaitForSeconds(ShakeDeltaTime);
            }

            SetShakeMechanicToOriginalPosition();

            _isShaking = false;
        }

        private Vector2 GetRandomOffsetPosition()
        {
            var xOffset = Random.Range(-ShakeStrength, ShakeStrength);
            var yOffset = Random.Range(-ShakeStrength, ShakeStrength);
            return new Vector2(xOffset, yOffset);
        }

        private void SetShakeMechanicToOriginalPosition()
        {
            shakeMechanicRectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
