using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChunk : MonoBehaviour
{
    public GameObject targetMap;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MapController.Instance.CurrentChunk = targetMap;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (MapController.Instance.CurrentChunk == targetMap)
            {
                MapController.Instance.CurrentChunk = null;
            }
        }
    }
}
