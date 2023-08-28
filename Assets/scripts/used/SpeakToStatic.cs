using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakToStatic : MonoBehaviour
{
    [SerializeField] string Usage;
    public int WhichOb;
    public float Value;
    public bool BoolValue;
    private void Awake()
    {
        if (WhichOb == 8) { Static.bullet = gameObject; }
    }
    private void Start()
    {
        if (WhichOb == 0) { Static.player = gameObject; Static.playerRg = gameObject.GetComponent<Rigidbody2D>(); }
        if (WhichOb == 1) { Static.cam = gameObject; }
        if (WhichOb == 2) { Static.desire = gameObject; }
        if (WhichOb == 5) { Static.respawn = gameObject; }
        if (WhichOb == 6) { Static.bulletspawn = gameObject; }
        if (WhichOb == 101) { Static.speed = Value; }
        if (WhichOb == 102) { Static.MaxVelo = Value; }
        if (WhichOb == 103) { Static.CoyoteBas = Value; }
        if (WhichOb == 104) { Static.JumpBuff = Value; }
        if (WhichOb == 105) { Static.JumpStr = Value; }
        if (WhichOb == 106) { Static.FallMult = Value; }
        if (WhichOb == 109) { Static.BulletDis = Value; }
        if (WhichOb == 120) { Static.EnemyRayDis = Value; }
        if (WhichOb == 201) { Static.LineView = BoolValue; }
    }
    
}
