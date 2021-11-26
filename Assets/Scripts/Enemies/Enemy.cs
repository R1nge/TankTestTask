using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public float health;
    public float protection;
    public float speed;
    public float damage;

    public void TakeDamage(float amount)
    {
        health -= amount * protection;
        if (health <= 0)
        {
            OnDeath();
        }
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.TryGetComponent(out IDamageable damageable);
            damageable.TakeDamage(damage);
        }
    }
}