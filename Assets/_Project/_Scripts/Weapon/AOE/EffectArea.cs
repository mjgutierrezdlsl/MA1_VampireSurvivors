using UnityEngine;

public class EffectArea : MonoBehaviour
{
    float _damageAmount;
    float _effectRadius;
    public void Initialize(AOEData data)
    {
        _damageAmount = data.DamageAmount;
        _effectRadius = data.EffectRadius;
        transform.localScale *= _effectRadius;
        Destroy(gameObject, data.EffectDuration);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            enemy.TakeDamage(_damageAmount);
        }
    }
}