using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [Header("Weapons")]
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Weapon[] weapons;
    private int _weaponIndex;

    [Header("Tank Stats")]
    [SerializeField] private int speed;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float health;

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
        CheckBorders();
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

    private void CheckBorders()
    {
        Vector3 pos = transform.position;

        if (pos.x > 7.85f) pos.x = 7.85f;
        if (pos.x < -7.85f) pos.x = -7.85f;

        if (pos.y > 4.5f) pos.y = 4.5f;
        if (pos.y < -4.5f) pos.y = -4.5f;
        transform.position = pos;
    }

    private void Respawn()
    {
        Instantiate(gameObject, new Vector3(0, 0, 0), quaternion.identity);
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Respawn();
        }
    }
}