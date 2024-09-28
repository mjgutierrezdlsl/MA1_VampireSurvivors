using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _maxHealth = 5f;
    float _currentHealth;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rb2D;
    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void FixedUpdate()
    {
        if (_currentHealth <= 0) { return; }

        _rb2D.MovePosition(Vector2.MoveTowards(_rb2D.position, _player.position, _moveSpeed * Time.fixedDeltaTime));
    }
    public void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        if (_currentHealth <= 0f)
        {
            _spriteRenderer.DOColor(Color.black, 1f).SetEase(Ease.InOutQuad).OnComplete(() => Destroy(gameObject));
        }
    }
}
