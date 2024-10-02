using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Singleton<CoinSpawner>
{
    [SerializeField] int amount = 100;
    [SerializeField] Coin prefab;
    private Stack<Coin> _availableCoins = new();
    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            var coin = Instantiate(prefab, transform);
            coin.gameObject.SetActive(false);
            _availableCoins.Push(coin);
        }
    }
    public Coin GetCoin()
    {
        var coin = _availableCoins.Pop();
        coin.gameObject.SetActive(true);
        return coin;
    }

    public void ReturnCoin(Coin coin)
    {
        _availableCoins.Push(coin);
    }
}
