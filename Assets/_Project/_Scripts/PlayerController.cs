using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _maxHealth = 100f;
    [SerializeField] Image _healthBarFill;
    float _currentHealth = 0;
    Rigidbody2D _rb2D;
    Vector2 _moveDirection;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void Update()
    {
        _moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveDirection.Normalize();

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
