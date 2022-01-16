using Unity.Mathematics;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
	private Health _health;

	private void Awake ()
	{
		_health = GetComponent<Health>();
		_health.OnDieEvent += Respawn;
	}

	private void Respawn ()
	{
		Instantiate(gameObject, new Vector3(0, 0, 0), quaternion.identity);
		Destroy(gameObject);
	}

	private void OnDestroy ()
	{
		_health.OnDieEvent -= Respawn;
	}
}
