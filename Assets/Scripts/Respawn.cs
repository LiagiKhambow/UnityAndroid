using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private BoxCollider2D _boxCollider;

    public GameObject respawnPoint;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            collider.GetComponent<Transform>().position = respawnPoint.transform.position;
        }
    }
}
