using System;
using UnityEngine;
public class PlayerInput : MonoBehaviour
{
	public bool MoveForward { get; private set; }
	public bool RotateLeft { get; private set; }
	public bool RotateRight { get; private set; }

	public event Action ShootEvent = delegate {};
	public event Action<int> SwapWeaponEvent = delegate {};

	private void Update ()
	{
		MoveForward = Input.GetKey(KeyCode.UpArrow);

		RotateLeft = Input.GetKey(KeyCode.LeftArrow);

		RotateRight = Input.GetKey(KeyCode.RightArrow);

		if (Input.GetButtonDown("Fire1"))
			ShootEvent?.Invoke();

		if (Input.GetKeyDown(KeyCode.Q))
			SwapWeaponEvent?.Invoke(1);

		if (Input.GetKeyDown(KeyCode.W))
			SwapWeaponEvent?.Invoke(-1);
	}
}
