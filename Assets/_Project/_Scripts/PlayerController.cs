using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _maxHealth = 100f;
    [SerializeField] Image _healthBarFill;
    float _currentHealth = 0;
    Rigidbody2D _rb2D;
    SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    Vector2 _moveDirection;

    protected override void Awake()
    {
        base.Awake();
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void Update()
    {
        _moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveDirection.Normalize();

        if (_moveDirection.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_moveDirection.x > 0)
        {
            _spriteRenderer.flipX = false;
        }

        _healthBarFill.fillAmount = _currentHealth / _maxHealth;
    }
    private void FixedUpdate()
    {
        _rb2D.MovePosition(_rb2D.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            _currentHealth--;
        }
    }
}
