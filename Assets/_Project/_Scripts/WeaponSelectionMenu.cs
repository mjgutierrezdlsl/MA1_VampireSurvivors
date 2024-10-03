using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionMenu : MonoBehaviour
{
    [SerializeField] WeaponSelectionItem _selectionPrefab;
    List<WeaponSelectionItem> _selections = new();
    private void OnEnable()
    {
        foreach (var weapon in WeaponManager.Instance.Weapons)
        {
            var selection = Instantiate(_selectionPrefab, transform);
            selection.Initialize(weapon);
            selection.GetComponent<Button>().onClick.AddListener(() => gameObject.SetActive(false));
            _selections.Add(selection);
        }
    }
    private void OnDisable()
    {
        foreach (var selection in _selections)
        {
            Destroy(selection.gameObject);
        }
        _selections.Clear();
    }
}
