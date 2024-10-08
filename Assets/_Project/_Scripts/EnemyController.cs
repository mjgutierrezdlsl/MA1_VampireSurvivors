using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _maxHealth = 5f;
    [SerializeField] float _deathDuration = 0.3f;
    EnemySpawner _spawner;
    Transform _player;
    float _currentHealth;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rb2D;
    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Initialize(Transform player, EnemySpawner spawner)
    {
        _player = player;
        _spawner = spawner;
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void OnDisable()
    {
        _currentHealth = _maxHealth;
        _spriteRenderer.color = Color.white;
    }
    private void FixedUpdate()
    {
        if (!_player) { return; }
        if (_currentHealth <= 0) { return; }

        _rb2D.MovePosition(Vector2.MoveTowards(_rb2D.position, _player.position, _moveSpeed * Time.fixedDeltaTime));
    }
    public void ResetToDefault()
    {
        _currentHealth = _maxHealth;
        _spriteRenderer.color = Color.white;
    }
    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        print($"{name}: {_currentHealth}");
        if (_currentHealth <= 0f)
        {
            StartCoroutine(DeathRoutine());
        }
    }
    IEnumerator DeathRoutine()
    {
        float time = 0;
        while (time < _deathDuration)
        {
            _spriteRenderer.color = Color.Lerp(Color.white, Color.black, time / _deathDuration);
            time += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
        ResetToDefault();
        _spawner.ReturnEnemyToPool(this);
        var coin = CoinSpawner.Instance.GetCoin();
        coin.transform.position = transform.position;

    }
}
