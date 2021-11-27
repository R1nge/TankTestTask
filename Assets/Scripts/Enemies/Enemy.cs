using Pathfinding;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    public float health;
    public float takenDamageMultiplier;
    public float speed;
    public float damage;
    public AIDestinationSetter aiDestinationSetter;
    public AIPath aiPath;

    private void Awake()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();

        aiPath.maxSpeed = speed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount * takenDamageMultiplier;
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