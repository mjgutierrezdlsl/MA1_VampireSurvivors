using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody2D _rb2D;
    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _rb2D.MovePosition(Vector2.MoveTowards(_rb2D.position, _player.position, _moveSpeed * Time.fixedDeltaTime));
    }
}
