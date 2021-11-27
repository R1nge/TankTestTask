using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public int damage;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}