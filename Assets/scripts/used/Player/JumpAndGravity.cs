using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    float jumpforce;
    Rigidbody2D Rg;
    GameObject cam;
    Camera camer;
    CircleCollider2D boxer;
    public LayerMask mask;
    float coyoteBase, JumpBase;
    public float coyoteTimer, JumpBufferTimer;
    public float Fallspeed;
    public float g;
    private void Start()
    {
        Fallspeed = Static.FallMult;
        jumpforce = Static.JumpStr;
        coyoteBase = Static.CoyoteBas;
        JumpBase = Static.JumpBuff;
        Rg = gameObject.GetComponent<Rigidbody2D>();
        cam = Static.cam;
        camer = cam.GetComponent<Camera>();
        boxer = gameObject.GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) { Fallspeed = Static.FallMult - 1.5f; } else { Fallspeed = Static.FallMult; }
        if (grounded()) { coyoteTimer = coyoteBase; }
        else { coyoteTimer = coyoteTimer - Time.deltaTime; Rg.velocity = new Vector2(Rg.velocity.x, Rg.velocity.y + (Physics2D.gravity.y * (Fallspeed - 1) * Time.deltaTime)); }

        if (Input.GetKeyDown(KeyCode.Space)) { JumpBufferTimer = JumpBase; }
        else
        {
            JumpBufferTimer -= Time.deltaTime;
            if (JumpBufferTimer > 0f && coyoteTimer > 0f) { Rg.velocity = new Vector2(Rg.velocity.x, 0); Jump(); JumpBufferTimer = 0; }
            if (Input.GetKeyUp(KeyCode.Space) & Rg.velocity.y > 0) { coyoteTimer = 0; }

        }
        bool grounded()
        {
            float extra = 0.15f;

            RaycastHit2D hit = Physics2D.BoxCast(boxer.bounds.center, boxer.bounds.size, 0f, Vector2.down, extra, mask);
            if (hit.collider != null) { return true; } else { return false; }
        }
        void Jump()
        {
            Rg.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }
    
}
