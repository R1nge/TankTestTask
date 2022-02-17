using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;
    private Weapon _currentWeapon;
    private int _weaponIndex;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.ShootEvent += Shoot;
        _playerInput.SwapWeaponEvent += SwapWeapons;
    }

    private void Start()
    {
        _currentWeapon = weapons[0];
        _currentWeapon.gameObject.SetActive(true);
    }

    private void Shoot()
    {
        _currentWeapon.Shoot(_currentWeapon.damage);
    }

    private void SwapWeapons(int index)
    {
        if (_weaponIndex + index >= 0 && _weaponIndex + index <= weapons.Length - 1)
        {
            _currentWeapon.gameObject.SetActive(false);
            _weaponIndex += index;
            _currentWeapon = weapons[_weaponIndex];
            _currentWeapon.gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        _playerInput.ShootEvent -= Shoot;
        _playerInput.SwapWeaponEvent -= SwapWeapons;
    }
}