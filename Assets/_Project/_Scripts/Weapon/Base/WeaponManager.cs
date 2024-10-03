using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    [SerializeField] Transform weaponParent;
    [SerializeField] List<WeaponData> _weapons = new();
    public WeaponData[] Weapons => _weapons.ToArray();

    private void Start()
    {
        // Activates the default weapon for the player
        ActivateWeapon(_weapons[0]);
    }
    private void OnEnable()
    {
        foreach (var weapon in _weapons)
        {
            weapon.OnWeaponActivate += ActivateWeapon;
        }
    }

    private void OnDisable()
    {
        foreach (var weapon in _weapons)
        {
            weapon.OnWeaponActivate -= ActivateWeapon;
        }
    }

    public void ActivateWeapon(WeaponData weaponData)
    {
        var weapon = Instantiate(weaponData.WeaponPrefab, weaponParent);
        weapon.Initialize(weaponData);
    }
}
