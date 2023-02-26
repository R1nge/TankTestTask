using System;
using Pathfinding;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        public AIDestinationSetter aiDestinationSetter;
        private AIPath aiPath;
        private Health _health;

        public event Action<Enemy> OnEnemyDiedEvent;

        private void Awake()
        {
            aiDestinationSetter = GetComponent<AIDestinationSetter>();
            aiPath = GetComponent<AIPath>();
            _health = GetComponent<Health>();
            _health.OnDieEvent += OnDeath;
            aiPath.maxSpeed = speed;
        }

        private void OnDeath()
        {
            OnEnemyDiedEvent?.Invoke(this);
            Destroy(gameObject);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            if (other.transform.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
            }
        }

        private void OnDestroy() => _health.OnDieEvent -= OnDeath;
    }
}