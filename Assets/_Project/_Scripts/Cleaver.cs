using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaver : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float _attackInterval = 1f;
    [SerializeField] float _damageAmount;
    [SerializeField] PlayerController _playerController;
    IEnumerator Start()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(_attackInterval);
            _animator.SetTrigger(_playerController.SpriteRenderer.flipX ? "attack_left" : "attack_right");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            print($"Trigger: {enemy.name}");
            enemy.TakeDamage(_damageAmount);
        }
    }
}
