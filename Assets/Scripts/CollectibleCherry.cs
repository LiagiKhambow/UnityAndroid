using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCherry : MonoBehaviour
{
    private AudioSource _audioSource;
    private PlayerControllerNew player;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            _audioSource.Play();
            _spriteRenderer.enabled = false;
            _circleCollider.enabled = false;
            player = collider.GetComponent<PlayerControllerNew>();
            player.TouchedCollectible();
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
    
}
