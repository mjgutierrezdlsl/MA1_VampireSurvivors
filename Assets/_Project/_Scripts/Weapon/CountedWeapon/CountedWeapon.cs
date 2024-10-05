using UnityEngine;

public class CountedWeapon : MonoBehaviour
{
    private float DamageAmount;
    private int Health;
    public void Initialize(CountedWeaponData data)
    {
        DamageAmount = data.DamageAmount;
        Health = data.HitsToTake;
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            enemy.TakeDamage(DamageAmount);
            Health--;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}