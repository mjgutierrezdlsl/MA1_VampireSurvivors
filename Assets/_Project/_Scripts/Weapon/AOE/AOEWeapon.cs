using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public abstract class AOEWeapon : MonoBehaviour
{
    [SerializeField] EffectArea _effectVisualizer;
    public void Initialize(AOEData data, Vector2 targetPosition)
    {
        StartCoroutine(MoveToTarget(data, targetPosition));
    }
    private IEnumerator MoveToTarget(AOEData data, Vector2 targetPosition)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        while (time < data.SpawnSpeed)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / data.SpawnSpeed);
            time += Time.deltaTime;
            yield return null;
        }
        var effect = Instantiate(_effectVisualizer, targetPosition, Quaternion.identity);
        effect.Initialize(data);
        Destroy(gameObject);
    }
}