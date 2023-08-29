using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwitchMovementType : MonoBehaviour
{
    public float Xdis,Ydis;
    public GameObject player;
    public float Xdiff,Ydiff;
    void Start()
    {
        Xdis = Static.EnemyLookDis;
        Ydis = Static.EnemyLookUpDis;
        player = Static.player;
     }


    void Update()
    {
        
        Xdiff = transform.position.x - player.transform.position.x;
        Ydiff =  player.transform.position.y - transform.position.y;
        
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(Xdiff) < Xdis & Mathf.Abs(Ydiff) < Ydis) { playerseen(); }
    }
    void playerseen()
    {
        transform.position = transform.position - transform.right * (Xdiff / 5) * Time.deltaTime * (Static.speed / 5);
        turntoplayer();
    }
    void turntoplayer()
    {
        if (Xdiff < -1) { transform.localScale = (new Vector3(-1, 1, 1)); }
        if (Xdiff > 1) { transform.localScale = new Vector3(1, 1, 1); }
    }
}
