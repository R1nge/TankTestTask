using Enemies;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] objectsToSpawn;
    [SerializeField] private int targetSpawnAmount;
    [SerializeField] private float maxSpawnDistance;
    private int _spawnedAmount;
    private Camera _camera;

    private void Awake() => _camera = Camera.main;

    private void Start()
    {
        for (int i = 0; i < targetSpawnAmount; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        var inst = Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Length)], GetSpawnPosition(),
            Quaternion.identity);
        inst.OnEnemyDiedEvent += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        Spawn();
        enemy.OnEnemyDiedEvent -= OnEnemyDied;
    }

    private Vector3 GetSpawnPosition()
    {
        var pos = new Vector3(
            Random.Range(-maxSpawnDistance, maxSpawnDistance),
            Random.Range(-maxSpawnDistance, maxSpawnDistance),
            10);
        while (pos.x >= 0 && pos.x <= 1 || pos.y >= 0 && pos.y <= 1)
        {
            pos = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 10);
        }

        pos = _camera.ViewportToWorldPoint(pos);
        return pos;
    }
}