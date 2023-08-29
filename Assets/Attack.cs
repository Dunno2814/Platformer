using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider == Static.player ) { GameObject.Destroy(Static.player); }
    }
}
