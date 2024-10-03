using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapons/New AOE Weapon Data")]
public class AOEData : WeaponData
{
    [field: SerializeField] public int Amount { get; private set; }
    [field: SerializeField] public float SpawnSpeed { get; private set; }
    [field: SerializeField] public float SpawnRadius { get; private set; }
    [field: SerializeField] public float EffectRadius { get; private set; }
    [field: SerializeField] public float EffectDuration { get; private set; }
}