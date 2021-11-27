using Pathfinding;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public float health;
    public float protection;
    public float speed;
    public float damage;
    public AIDestinationSetter aiDestinationSetter;

    private void Awake()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount * protection;
        if (health <= 0)
        {
            OnDeath();
        }
    }


    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.TryGetComponent(out IDamageable damageable);
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}