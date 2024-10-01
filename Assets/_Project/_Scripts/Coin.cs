using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform _player;
    [SerializeField] float _duration = 1f;
    Vector2 velocity;
    private void OnDestroy()
    {
        ExperienceManager.Instance.TotalExperiencePoints++;
    }
    private void FixedUpdate()
    {
        if (!_player)
        {
            return;
        }
        transform.position = Vector2.SmoothDamp(transform.position, _player.position, ref velocity, _duration);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
