using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorailController : MonoBehaviour
{
    public PlayerMovement player;

    private void Start()
    {
        player.canDashTutorial = false;
        player.canTeleportTutorial = false;
    }
}
