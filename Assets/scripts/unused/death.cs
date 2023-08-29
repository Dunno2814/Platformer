using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Static.player.tag ) { Static.player.transform.position = Static.respawn.transform.position; Static.playerRg.velocity = new Vector3(0, 0, 0);  }
    }
}
