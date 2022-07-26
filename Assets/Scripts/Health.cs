using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health, maxHealth;
    [SerializeField] private float takenDamageMultiplier;
    public event Action OnDieEvent;

    private void Start() => health = maxHealth;

    public void TakeDamage(float amount)
    {
        health -= amount * takenDamageMultiplier;
        if (health <= 0)
        {
            OnDieEvent?.Invoke();
        }
    }
}