using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public static float health = 1f;
    private Vector2 movementSpeed = new Vector2(5f,0f);
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = movementSpeed;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            Debug.Log("Player Hit");
        }

        if (collider.tag.Equals("Wall"))
        {
            if (movementSpeed.x > 0)
            {
                movementSpeed.x = -5f;
            }
            else
            {
                movementSpeed.x = 5f;
            }
        }
    }

    public void Hit()
    {
        health -= 0.2f;
    }

}
