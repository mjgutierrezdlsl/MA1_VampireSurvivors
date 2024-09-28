using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField] EnemyController _enemyPrefab;
    [SerializeField] float _spawnInterval;
    [SerializeField] int _enemyLimit = 10;
    Queue<EnemyController> _availableEnemies = new();
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Start()
    {
        InstantiateEnemies();
        InvokeRepeating(nameof(SpawnEnemy), 1f, _spawnInterval);
    }

    private void InstantiateEnemies()
    {
        for (int i = 0; i < _enemyLimit; i++)
        {
            // Spawn enemies
            var enemy = Instantiate(_enemyPrefab, transform);
            enemy.Initialize(_player.transform, this);
            enemy.gameObject.SetActive(false);
            _availableEnemies.Enqueue(enemy);
        }
    }

    public void ReturnEnemyToPool(EnemyController enemy)
    {
        _availableEnemies.Enqueue(enemy);
        print($"{enemy.name} returned to queue");
    }

    private void SpawnEnemy()
    {
        // Initial Random.Range determines Left/Right side
        var spawnX = Random.Range(0f, 1f);
        if (spawnX < 0.5f)
        {
            spawnX = 0 - Random.Range(0f, 1f);
        }
        else
        {
            spawnX = 1 + Random.Range(0f, 1f);
        }
        var spawnY = Random.Range(0f, 1f);
        if (spawnY < 0.5f)
        {
            spawnY = 0 - Random.Range(0f, 1f);
        }
        else
        {
            spawnY = 1 + Random.Range(0f, 1f);
        }
        var spawnPosition = _camera.ViewportToWorldPoint(new(spawnX, spawnY, 10f));
        if (_availableEnemies.Count <= 0)
        {
            // Debug.LogWarning($"No enemy returned from queue. Instantiating {_enemyLimit} enemies. Will be used on next call.");
            // InstantiateEnemies();
            return;
        }
        var enemy = _availableEnemies.Dequeue();
        enemy.transform.position = spawnPosition;
        enemy.gameObject.SetActive(true);
    }
}
