using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action OnMoveForwardEvent;
    public event Action OnRotateLeftEvent;
    public event Action OnRotateRightEvent;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            OnMoveForwardEvent?.Invoke();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnRotateLeftEvent?.Invoke();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            OnRotateRightEvent?.Invoke();
        }
    }
}