/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private PlayerController player;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerController>())
        {
            player = collider.GetComponent<PlayerController>();
            player.canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerController>())
        {
            player = collider.GetComponent<PlayerController>();
            player.canClimb = false;
            player.GetComponent<Animator>().SetBool("isClimbing",false);
        }
    }
}
*/
