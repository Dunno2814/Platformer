using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SwitchMovementType : MonoBehaviour
{
    public float Xdis,Ydis;
    public GameObject player;
    public float Xdiff,Ydiff;
    public float enemyspeed;
    public int health;
    void Start()
    {
        health = 5;
        enemyspeed = 9f;
        Xdis = 25f;
        Ydis = 5f;
        player = Static.player;
     }


    void Update()
    {
        
        Xdiff = transform.position.x - player.transform.position.x;
        Ydiff =  player.transform.position.y - transform.position.y;
        if ( health <= 0) { GameObject.Destroy(gameObject); }
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(Xdiff) < Xdis & Mathf.Abs(Ydiff) < Ydis) { playerseen(); }
    }
    void playerseen()
    {
        transform.position = transform.position - transform.right * Time.deltaTime * (enemyspeed);
        turntoplayer();
    }
    void turntoplayer()
    {
        if (Xdiff < -1) { transform.localScale = (new Vector3(-1, 1, 1)); }
        if (Xdiff > 1) { transform.localScale = new Vector3(1, 1, 1); }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == Static.player ) { GameObject.Destroy(Static.player); }
        if (collision.collider.gameObject.tag == "Bullet") { health = health - 1; }
    }
}
