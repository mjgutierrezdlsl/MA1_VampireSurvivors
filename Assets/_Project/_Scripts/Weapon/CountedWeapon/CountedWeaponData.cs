using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapons/New Counted Weapon Data")]
public class CountedWeaponData : WeaponData
{
    [field: SerializeField] public int HitsToTake { get; private set; }
}