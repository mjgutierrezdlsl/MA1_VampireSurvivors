using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaver : WeaponController
{
    [SerializeField] Animator _animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            print($"Trigger: {enemy.name}");
            enemy.TakeDamage(_damageAmount);
        }
    }

    public override IEnumerator EnableWeapon()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(_coolDownTime);
            _animator.SetTrigger(PlayerController.Instance.SpriteRenderer.flipX ? "attack_left" : "attack_right");
        }
    }
}
