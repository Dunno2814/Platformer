using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimatplayer : MonoBehaviour
{
    Vector3 dis;
    public LayerMask PlayerCheck;
    private void Start()
    {
        
    }
    void Update()
    {
        dis = transform.position - Static.player.transform.position;
        Debug.Log(dis);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dis.normalized, 10f, PlayerCheck);
        Debug.Log(hit.collider);
    }
}
