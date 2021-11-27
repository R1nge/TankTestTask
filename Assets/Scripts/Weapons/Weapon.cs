using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public Transform shootPoint;
    public Rigidbody2D projectilePrefab;
    public int projectileSpeed;
    public abstract void Shoot(int damage);
}