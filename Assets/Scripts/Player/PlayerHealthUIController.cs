namespace Player
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerHealthUIController : MonoBehaviour
    {
        [SerializeField] private Image healthUI;
        [SerializeField] private TextMeshProUGUI healthAmountText;

        private const float HealthUIMaxCirclePercentage = 0.75f;

        public void SetHealthAmountText(int healthCurrentValue)
        {
            healthAmountText.text = healthCurrentValue.ToString();
        }

        public void ChangeHealthUIFill(int healthCurrentValue, int healthMaxValue)
        {
            var fillAmount = CalculateHealthUIFillAmount(healthCurrentValue, healthMaxValue);
            
            healthUI.fillAmount = fillAmount;
        }

        private float CalculateHealthUIFillAmount(int healthCurrentValue, int healthMaxValue)
        {
            return HealthUIMaxCirclePercentage * healthCurrentValue / healthMaxValue;
        }
    }
}
