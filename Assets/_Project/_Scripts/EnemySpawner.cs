using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] PlayerController _player;
    [SerializeField] EnemyController _enemyPrefab;
    [SerializeField] float _spawnInterval;
    [SerializeField] int _enemyLimit = 10;
    List<EnemyController> _spawnedEnemies = new();
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, _spawnInterval);
    }
    private void SpawnEnemy()
    {
        // if (_spawnedEnemies.Count >= _enemyLimit) { return; }
        var spawnX = Random.Range(0f, 1f);
        if (spawnX < 0.5f)
        {
            spawnX -= 0;
        }
        else
        {
            spawnX += 1;
        }
        var spawnY = Random.Range(0f, 1f);
        if (spawnY < 0.5f)
        {
            spawnY -= 0;
        }
        else
        {
            spawnY += 1;
        }
        var spawnPosition = _camera.ViewportToWorldPoint(new(spawnX, spawnY, 10f));
        var enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.Initialize(_player.transform);
        _spawnedEnemies.Add(enemy);
    }
}
