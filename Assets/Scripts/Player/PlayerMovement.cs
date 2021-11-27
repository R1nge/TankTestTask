using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int rotationSpeed;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();

        _playerInput.OnMoveForwardEvent += MoveForward;
        _playerInput.OnRotateLeftEvent += RotateLeft;
        _playerInput.OnRotateRightEvent += RotateRight;
    }

    private void MoveForward()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void RotateLeft()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
    }

    private void RotateRight()
    {
        transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
    }
}