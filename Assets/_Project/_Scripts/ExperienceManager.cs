using System;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] private AnimationCurve _levelCurve;
    public int _currentLevel;
    public int CurrentLevel
    {
        get => _currentLevel;
        set
        {
            _currentLevel = Mathf.Clamp(value, 0, MaxLevel);
            OnCurrentLevelChanged?.Invoke(_currentLevel);
        }
    }
    public int PrevPoints => (int)_levelCurve.Evaluate(CurrentLevel);
    public int MaxLevel => (int)_levelCurve.keys[_levelCurve.length - 1].time;
    public int NextPoints => (int)_levelCurve.Evaluate(CurrentLevel + 1);
    public int MaxPoints => (int)_levelCurve.Evaluate(MaxLevel);
    private int _totalExperiencePoints;
    public int TotalExperiencePoints
    {
        get => _totalExperiencePoints;
        set
        {
            _totalExperiencePoints = (int)Mathf.Clamp(value, 0, _levelCurve.Evaluate(MaxLevel));
            OnTotalExperiencePointsChanged?.Invoke(_totalExperiencePoints, NextPoints);
        }
    }
    public event Action<int> OnCurrentLevelChanged;
    public event Action<int, int> OnTotalExperiencePointsChanged;

    private float elapsed;
    private void Update()
    {
        if (elapsed < 10f)
        {
            elapsed += Time.deltaTime;
        }
        else
        {
            elapsed = 10f;
        }
        if (TotalExperiencePoints >= NextPoints)
        {
            CurrentLevel++;
        }
        TotalExperiencePoints = (int)_levelCurve.Evaluate(elapsed);
    }
}
