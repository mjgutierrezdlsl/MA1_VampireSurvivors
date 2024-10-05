using System.Collections;
using UnityEngine;

public class CountedWeaponController : WeaponController
{
    [SerializeField] CountedWeapon _weapon;
    public override IEnumerator EnableWeapon()
    {
        var data = Data as CountedWeaponData;
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(data.CoolDownTime);
            var weapon = Instantiate(_weapon, transform);
            weapon.Initialize(data);
            if (!PlayerController.Instance.SpriteRenderer.flipX)
            {
                weapon.transform.position = transform.position + Vector3.right;
            }
            else
            {
                weapon.transform.position = transform.position - Vector3.right;
            }
        }
    }
}