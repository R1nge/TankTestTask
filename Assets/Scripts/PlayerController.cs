using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Weapon[] weapons;
    private int _weaponIndex;

    [Header("Tank Stats")]
    [SerializeField] private int speed;
    [SerializeField] private int rotationSpeed;

    private void Start()
    {
        currentWeapon = weapons[0];
        currentWeapon.gameObject.SetActive(true);
    }

    private void Update()
    {
        Shoot();
        SwapWeapons();
        Move();
        Rotate();
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


    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * speed * Time.deltaTime;
            print("Forward");
            print(speed);
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
        }
    }
}