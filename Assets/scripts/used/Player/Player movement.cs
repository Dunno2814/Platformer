using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    // <-->
    Rigidbody2D Rg;
    public float speed, maxVelo;
    // gravity
    float jumpforce;
    GameObject cam;
    Camera camer;
    BoxCollider2D boxer;
    public LayerMask mask;
    float coyoteBase, JumpBase;
    public float coyoteTimer, JumpBufferTimer;
    public float Fallspeed, Fallmult;
    public float g;
    private void Start()
    {
        Fallmult = 2.5f;
        jumpforce = 9f;
        coyoteBase = 0.4f;
        JumpBase = 0.15f;
        Rg = gameObject.GetComponent<Rigidbody2D>();
        cam = Static.cam;
        camer = cam.GetComponent<Camera>();
        boxer = gameObject.GetComponent<BoxCollider2D>();
        speed = 50f;
        maxVelo = 40f;
        Static.LookingRight = true;
    }
    void Update()
    {
        Rg.AddForce((Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed * Vector2.right), ForceMode2D.Impulse);
        Rg.velocity = new Vector2(Mathf.Clamp(Rg.velocity.x, -maxVelo, maxVelo), Rg.velocity.y);
        if (Input.GetAxisRaw("Horizontal") < 0) { transform.localScale = new Vector3(-3f, 3f, 1); Static.LookingRight = false; } else if (Input.GetAxisRaw("Horizontal") > 0) { transform.localScale = new Vector3(3f, 3f, 1); Static.LookingRight = true; }
        // movement is up, jump is down 
        if (Input.GetKey(KeyCode.Space)) { Fallspeed = Fallmult - 1.5f; } else { Fallspeed = Fallmult; }
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
