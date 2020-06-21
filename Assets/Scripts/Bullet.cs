using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 bulletVelocity = new Vector2(0f,0f);
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    
    private void FixedUpdate()
    {
        _rb.velocity = bulletVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.tag.Equals("Player") && !collider.tag.Equals("Collectible"))
        {
            Debug.Log("Entered: " + collider.name);
            Enemy enemyHit = collider.GetComponent<Enemy>();
            enemyHit.Hit();
            Destroy(this.gameObject);
        }
    }

    public void Fire(float bulletSpeed,bool isFacingRight)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        if (!isFacingRight)
        {
            _spriteRenderer.flipX = true;
            bulletSpeed *= -1;
        }
        bulletVelocity = new Vector2(bulletSpeed, 0f);
        Destroy(this.gameObject,3f);
    }
    
}
