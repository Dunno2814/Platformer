using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweakerViewer : MonoBehaviour
{
    public Vector3 Player;
    public GameObject play, ca, de, re, bu, busp;
    public Rigidbody2D PlayRg;
    public bool CanIShoot, CanISeeLine, LookingRight;
    public float movementSpeed, MaxVe, CoyoteB, JumpB, JumpS, BulDis, EnemyLookDis, EnemyLookUpDis;
    public int bulletCount;

    private void Start()
    {
        CanISeeLine = Static.LineView;
        play = Static.player;
        ca = Static.cam;
        de = Static.desire;
        re = Static.respawn;
        PlayRg = Static.playerRg;
        movementSpeed = Static.speed;
        MaxVe = Static.MaxVelo;
        CoyoteB = Static.CoyoteBas;
        JumpB = Static.JumpBuff;
        JumpS = Static.JumpStr;
        bu = Static.bullet;
        busp = Static.bulletspawn;
        BulDis = Static.BulletDis;
        EnemyLookDis = Static.EnemyLookDis;
        EnemyLookUpDis = Static.EnemyLookUpDis;
    }
    private void Update()
    {
        Player = Static.playerVec;
        CanIShoot = Static.canShoot;
        bulletCount = Static.bulletCount;
        LookingRight = Static.LookingRight;
    }
}
