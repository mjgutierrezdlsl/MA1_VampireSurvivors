using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : Singleton<MapController>
{
    [SerializeField] GameObject _terrainChunk;
    [SerializeField] float _checkerRadius;
    [SerializeField] LayerMask _terrainMask;
    public GameObject CurrentChunk;
    Vector3 _noTerrainPosition;
    Vector3 PlayerMoveDirection;
    List<GameObject> _activeChunks = new();
    GameObject latestChunk;
    [SerializeField] float maxDistanceFromChunk;
    float distanceFromChunk;
    private void Start()
    {
        SpawnChunk();
        InvokeRepeating(nameof(ChunkOptimizer), 1f, 1f);
    }
    private void Update()
    {
        PlayerMoveDirection = PlayerController.Instance.MoveDirection;
        ChunkChecker();
    }
    private void ChunkChecker()
    {
        if (!CurrentChunk) { return; }
        int xCheckCord = PlayerMoveDirection.x == 0 ? 0 : PlayerMoveDirection.x > 0 ? 20 : -20;
        int yCheckCord = PlayerMoveDirection.y == 0 ? 0 : PlayerMoveDirection.y > 0 ? 20 : -20;

        _noTerrainPosition = CurrentChunk.transform.position + new Vector3(xCheckCord, yCheckCord, 0);

        var chunk = Physics2D.OverlapCircle(_noTerrainPosition, _checkerRadius, _terrainMask);
        // print($"{_noTerrainPosition}|{chunk == null}");
        if (!chunk)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        latestChunk = Instantiate(_terrainChunk, _noTerrainPosition, Quaternion.identity);
        latestChunk.transform.SetParent(transform);
        _activeChunks.Add(latestChunk);
    }
    private void ChunkOptimizer()
    {
        foreach (var chunk in _activeChunks)
        {
            distanceFromChunk = Vector3.Distance(PlayerController.Instance.transform.position, chunk.transform.position);
            chunk.SetActive(distanceFromChunk < maxDistanceFromChunk);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(_noTerrainPosition, _checkerRadius);
    }
}
