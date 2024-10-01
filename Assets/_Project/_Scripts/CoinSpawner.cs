using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] int amount = 100;
    [SerializeField] int radius = 10;
    [SerializeField] Coin prefab;
    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            var coin = Instantiate(prefab, transform);
            coin.transform.position += (Vector3)Random.insideUnitCircle * radius;
        }
    }
}
