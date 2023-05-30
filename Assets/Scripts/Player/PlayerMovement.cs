using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private int speed;
        private Rigidbody2D _rigidbody2D;
        private IPlayerInput _playerInput;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerInput = GetComponent<IPlayerInput>();
        }

        private void FixedUpdate()
        {
            if (_playerInput.MoveForward)
            {
                Move(transform.up);
            }
        }

        private void Move(Vector2 direction)
        {
            _rigidbody2D.MovePosition(_rigidbody2D.position + direction * (speed * Time.fixedDeltaTime));
        }
    }
}