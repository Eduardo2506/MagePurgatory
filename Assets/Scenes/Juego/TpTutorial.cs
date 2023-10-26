using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpTutorial : MonoBehaviour
{
    public PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.EnableTeleport();
        }
    }
}
