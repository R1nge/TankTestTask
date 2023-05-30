using System;

public interface IPlayerInput
{
    bool MoveForward { get; }
    bool RotateLeft { get; }
    bool RotateRight { get; }

    event Action ShootEvent;
    event Action<int> SwapWeaponEvent;
}