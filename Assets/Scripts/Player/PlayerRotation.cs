using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private int rotationSpeed;
        private IPlayerInput _playerInput;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _playerInput = GetComponent<IPlayerInput>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_playerInput.RotateLeft)
            {
                Rotate(rotationSpeed);
            }
            else if (_playerInput.RotateRight)
            {
                Rotate(-rotationSpeed);
            }
        }

        private void Rotate(float speed) => _rigidbody2D.MoveRotation(_rigidbody2D.rotation + speed * Time.fixedDeltaTime);
    }
}