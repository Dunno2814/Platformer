using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakToStatic : MonoBehaviour
{
    [SerializeField] string Usage;
    public int WhichOb;
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
        if (WhichOb == 7) { Static.arm = gameObject; }
    }
    
}
