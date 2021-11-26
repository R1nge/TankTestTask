using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Weapon currentWeapon;
    private int _weaponIndex;

    private void Start()
    {
        currentWeapon = weapons[0];
        currentWeapon.gameObject.SetActive(true);
    }

    private void Update()
    {
        Shoot();
        SwapWeapons();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentWeapon.Shoot(currentWeapon.damage);
        }
    }

    private void SwapWeapons()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _weaponIndex < weapons.Length - 1)
        {
            currentWeapon.gameObject.SetActive(false);
            _weaponIndex++;
            currentWeapon = weapons[_weaponIndex];
            currentWeapon.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.W) && _weaponIndex > 0)
        {
            currentWeapon.gameObject.SetActive(false);
            _weaponIndex--;
            currentWeapon = weapons[_weaponIndex];
            currentWeapon.gameObject.SetActive(true);
        }
    }
}