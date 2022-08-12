namespace Player
{
    using UnityEngine;
    using System.Collections;

    public class PlayerSpriteController : MonoBehaviour
    {
        private PlayerData _playerData;
        private SpriteRenderer _playerSpriteRenderer;
        private Color _originalSpriteColor;
        private bool isInvulnerable;
    
        private void Awake()
        {
            _playerSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _originalSpriteColor = _playerSpriteRenderer.color;
        }
        
        public void SetPlayerData(PlayerData playerData)
        {
            _playerData = playerData;
            _playerSpriteRenderer.sprite = _playerData.sprite;
        }

        public void PlayerDamaged()
        {
            StartCoroutine(BlinkPlayerSprite());
        }
        
        private IEnumerator BlinkPlayerSprite()
        {
            isInvulnerable = true;
            
            for (float i = 0; i < _playerData.invulnerabilityDurationInSeconds; i+= _playerData.invulnerabilityDeltaTime)
            {
                _playerSpriteRenderer.color = _playerSpriteRenderer.color == _originalSpriteColor ? _playerData.invulnerabilityColor : _originalSpriteColor;

                yield return new WaitForSeconds(_playerData.invulnerabilityDeltaTime);
            }
            
            _playerSpriteRenderer.color = _originalSpriteColor;
            isInvulnerable = false;
        }
    }
}
