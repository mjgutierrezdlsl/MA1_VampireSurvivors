using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody2D _rb2D;
    Vector2 _moveDirection;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveDirection.Normalize();
    }
    private void FixedUpdate()
    {
        _rb2D.MovePosition(_rb2D.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
    }
}
