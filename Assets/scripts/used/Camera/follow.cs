using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject player;
    Transform Pt;
    float xMin = 0,yMin;

    void Start()
    {
        player = Static.player;
    }

    // Update is called once per frame
    void Update()
    {
        Pt = player.transform;
        transform.position = new Vector3( Mathf.Clamp(Pt.position.x - 2f,xMin,100f), Mathf.Clamp(Pt.position.y - 5f, yMin, 100f), transform.position.z);
    }
}
