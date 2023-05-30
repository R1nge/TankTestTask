using System;
using Pathfinding;
using Player;
using UnityEngine;
using VContainer;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float damage;
        [SerializeField] protected AIDestinationSetter aiDestinationSetter;
        private AIPath _aiPath;
        private Health _health;
        private Transform _playerTransform;

        public event Action<Enemy> OnEnemyDiedEvent;

        [Inject]
        private void Construct(PlayerController player)
        {
            _playerTransform = player.transform;
        }

        private void Awake()
        {
            aiDestinationSetter = GetComponent<AIDestinationSetter>();
            _aiPath = GetComponent<AIPath>();
            _health = GetComponent<Health>();
            _health.OnDieEvent += OnDeath;
            _aiPath.maxSpeed = speed;
        }

        private void Start() => aiDestinationSetter.target = _playerTransform;

        private void OnDeath()
        {
            OnEnemyDiedEvent?.Invoke(this);
            Destroy(gameObject);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerController player))
            {
                if (player.TryGetComponent(out Health health))
                {
                    health.TakeDamage(damage);
                }
            }
        }

        private void OnDestroy() => _health.OnDieEvent -= OnDeath;
    }
}