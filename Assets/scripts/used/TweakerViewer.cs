using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweakerViewer : MonoBehaviour
{
    public Vector3 Player;
    public GameObject play, ca, de, re, bu, busp;
    public Rigidbody2D PlayRg;

    private void Start()
    {
        play = Static.player;
        ca = Static.cam;
        de = Static.desire;
        re = Static.respawn;
        PlayRg = Static.playerRg;
    }
    private void Update()
    {
    }
}
