using System.Collections;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Enemy[] objectsToSpawn;
	[SerializeField] private float spawnInterval;
	[SerializeField] private int targetSpawnAmount;
	[SerializeField] private float minDistance;
	[SerializeField] private float maxDistance;
	private int _spawnedAmount;

	private void Start ()
	{
		StartCoroutine(Spawn_c());
	}

	private IEnumerator Spawn_c ()
	{
		while (enabled)
		{
			_spawnedAmount = FindObjectsOfType<Enemy>().Length;
			if (_spawnedAmount < targetSpawnAmount)
			{
				Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], GetSpawnPosition(), Quaternion.identity);
			}

			yield return new WaitForSeconds(spawnInterval);
		}
	}

	private Vector3 GetSpawnPosition ()
	{
		Vector3 pos = (Random.insideUnitCircle.normalized*Random.Range(minDistance, maxDistance));
		return pos;
	}
}
