using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] List<WeaponData> _weapons = new();

    private void Start()
    {
        ActivateWeapon(_weapons[0]);
    }

    public void ActivateWeapon(WeaponData weaponData)
    {
        var weapon = Instantiate(weaponData.WeaponPrefab, transform);
        weapon.Initialize(weaponData);
    }
}
