namespace Player
{
    using System;
    using UnityEngine;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : MonoBehaviour
    {
        public Animator animator;

        public event Action OnPlayerMove;

        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveDirection;
        private Vector3 _mousePosition;
        private Vector3 _mouseWorldPosition;
        private PlayerData _playerData;

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ProcessInput();            
        }

        private void FixedUpdate()
        {
            // Physics
            if (_moveDirection == Vector2.zero)
            {
                _rigidbody2D.velocity = Vector2.zero;
                return;
            }
            
            MovePlayer();
        }
        
        public void SetPlayerData(PlayerData playerData)
        {
            _playerData = playerData;
        }

        private void ProcessInput()
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");

            var currentSpeed = Mathf.Abs(_moveDirection.x) + Mathf.Abs(_moveDirection.y);
            animator.SetFloat("Speed", currentSpeed);

            if (currentSpeed == 0)
            {
                _moveDirection = Vector2.zero;;
            }
            _moveDirection = new Vector2(moveX, moveY);
        }

        private void MovePlayer()
        {          
            _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDirection * (_playerData.moveSpeed * Time.fixedDeltaTime));
            OnPlayerMove?.Invoke();
        }
    }
}   
