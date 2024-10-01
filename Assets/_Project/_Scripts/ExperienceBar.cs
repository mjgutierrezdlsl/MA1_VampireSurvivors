using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    [SerializeField] ExperienceManager _expManager;
    [SerializeField] Image _fillImage;
    private void OnEnable()
    {
        _expManager.OnTotalExperiencePointsChanged += OnExpChanged;
    }
    private void OnDisable()
    {
        _expManager.OnTotalExperiencePointsChanged -= OnExpChanged;
    }

    private void OnExpChanged(int total, int next)
    {
        // _fillImage.fillAmount = arg1 / (float)arg2;
        var remaining = (float)Mathf.InverseLerp((float)_expManager.PrevPoints, (float)next, (float)total);
        _fillImage.fillAmount = remaining;
        print(remaining);
    }
}
