namespace Player
{
    using UnityEngine;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : MonoBehaviour
    {
        public float moveSpeed;
        public Animator animator;
        public bool isFlipped;

        private Rigidbody2D _rigidbody2D;
        private Vector2 _moveDirection;
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
            Move();

        }
        
        public void SetPlayerData(PlayerData playerData)
        {
            _playerData = playerData;
        }

        private void ProcessInput()
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");

            _moveDirection = new Vector2(moveX, moveY).normalized;
        }

        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_moveDirection.x * _playerData.moveSpeed, _moveDirection.y * moveSpeed);
            
            animator.SetFloat("Speed", (Mathf.Abs(_moveDirection.x)+ Mathf.Abs(_moveDirection.y)));

            if(_moveDirection.x < 0 && isFlipped == false)          
            {                     
                animator.transform.Rotate(0, 180, 0);
                isFlipped = true;
            }
            if (_moveDirection.x > 0 && isFlipped == true)
            {
                animator.transform.Rotate(0, 180, 0);
                isFlipped = false;
            }


        }



    }
}   
