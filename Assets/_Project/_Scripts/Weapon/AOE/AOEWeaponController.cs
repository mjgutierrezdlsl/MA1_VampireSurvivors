using System.Collections;
using UnityEngine;

public class AOEWeaponController : WeaponController
{
    [SerializeField] protected AOEWeapon _aoeWeapon;
    public override IEnumerator EnableWeapon()
    {
        var data = Data as AOEData;
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(data.CoolDownTime);
            for (int i = 0; i < data.Amount; i++)
            {
                var spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * data.SpawnRadius;
                var weapon = Instantiate(_aoeWeapon, transform);
                weapon.Initialize(data, spawnPosition);
            }
        }
    }
}