using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullettoplayer : MonoBehaviour
{
    // Start is called before the first frame update
    
    Vector3 tf;
    Vector3 dir;
    float timer = 0f;
    float speed = 10f;
    void Start()
    {
         tf = Static.player.transform.position;
    }
    void Update()
    {
        dir = tf - transform.position;
        transform.position = transform.position + (dir * Time.deltaTime * speed);
        timer = timer + Time.deltaTime;
        if (timer > 2f || transform.position == tf) { Destroy(gameObject); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == Static.player & Static.bulletcount == 2 ) { Destroy(Static.player); }
    }
}
