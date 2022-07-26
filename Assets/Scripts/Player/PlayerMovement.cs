using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private int speed;
        [SerializeField] private int rotationSpeed;
        private PlayerInput _playerInput;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            //Mb not the best solution
            if (_rigidbody2D.velocity.magnitude != 0)
            {
                _rigidbody2D.velocity = Vector2.zero;
            }

            if (_playerInput.MoveForward)
            {
                MoveForward();
            }

            if (_playerInput.RotateLeft)
            {
                RotateLeft();
            }

            if (_playerInput.RotateRight)
            {
                RotateRight();
            }
        }

        private void MoveForward() =>
            _rigidbody2D.MovePosition(
                _rigidbody2D.position + (Vector2) transform.up * (speed * Time.fixedDeltaTime));

        private void RotateLeft() => _rigidbody2D.MoveRotation(_rigidbody2D.rotation + rotationSpeed);

        private void RotateRight() => _rigidbody2D.MoveRotation(_rigidbody2D.rotation - rotationSpeed);
    }
}