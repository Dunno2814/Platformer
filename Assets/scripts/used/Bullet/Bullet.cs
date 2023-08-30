using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject desire;
    Vector3 tf;
    Vector3 dir;
    float timer =0f;
    float speed = 10f;
    void Start()
    {
        desire = Static.desire; tf = desire.transform.position;
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
        if (collision.collider == desire || collision.collider.tag == "Ground") {  Destroy(gameObject); }
    }
}
