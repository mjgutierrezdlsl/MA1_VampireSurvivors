using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaver : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] float _attackInterval = 1f;
    [SerializeField] float _damageAmount;
    IEnumerator Start()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(_attackInterval);
            _animator.SetTrigger("attack");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent<EnemyController>(out var enemy))
        {
            enemy.TakeDamage(_damageAmount);
        }
    }
}
