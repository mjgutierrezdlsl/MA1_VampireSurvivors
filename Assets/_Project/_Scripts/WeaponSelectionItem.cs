using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionItem : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] TextMeshProUGUI _description;
    private WeaponData _data;
    public void Initialize(WeaponData data)
    {
        _data = data;
        _image.sprite = data.Sprite;
        _description.text = $"{data.name}\n{data.Description}";
    }
    public void SelectWeapon()
    {
        WeaponManager.Instance.ActivateWeapon(_data);
    }
}
