using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject player;
    Transform Pt;

    void Start()
    {
        player = Static.player;
    }

    // Update is called once per frame
    void Update()
    {
        Pt = player.transform;
        
    }
}
