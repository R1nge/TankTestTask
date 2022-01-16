using Pathfinding;
using UnityEngine;
public abstract class Enemy : MonoBehaviour
{
	public float speed;
	public float damage;
	public AIDestinationSetter aiDestinationSetter;
	public AIPath aiPath;
	private Health _health;

	private void Awake ()
	{
		aiDestinationSetter = GetComponent<AIDestinationSetter>();
		aiPath = GetComponent<AIPath>();
		_health = GetComponent<Health>();
		_health.OnDieEvent += OnDeath;

		aiPath.maxSpeed = speed;
	}

	protected virtual void OnDeath ()
	{
		Destroy(gameObject);
	}

	private void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.transform.TryGetComponent(out Health health);
			health.TakeDamage(damage);
		}
	}

	private void OnDestroy ()
	{
		_health.OnDieEvent -= OnDeath;
	}
}
