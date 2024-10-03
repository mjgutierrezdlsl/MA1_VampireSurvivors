using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    protected float _coolDownTime;
    protected float _damageAmount;
    public void Initialize(WeaponData data)
    {
        _coolDownTime = data.CoolDownTime;
        _damageAmount = data.DamageAmount;
        StartCoroutine(EnableWeapon());
    }
    public abstract IEnumerator EnableWeapon();
}
