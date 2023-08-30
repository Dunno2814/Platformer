using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

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
    public LayerMask mask, enemymask;
    float coyoteBase, JumpBase;
    public float coyoteTimer, JumpBufferTimer;
    public float Fallspeed, Fallmult;
    public float g;
    public Animator Animator2d;
    float RawInput;
    public bool spaceClick, SpaceHold, SpaceLift;
    private void Start()
    {
        jumpforce = 9f;
        coyoteBase = 0.4f;
        JumpBase = 0.15f;
        Rg = gameObject.GetComponent<Rigidbody2D>();
        cam = Static.cam;
        camer = cam.GetComponent<Camera>();
        boxer = gameObject.GetComponent<BoxCollider2D>();
        speed = 20f;
        maxVelo = 23f;
        Static.LookingRight = true;
    }
    void Update()
    {
        RawInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) {spaceClick = true; }
        if (Input.GetKey(KeyCode.Space)) { SpaceHold = true; Animator2d.SetBool("isJump", true); }
        if (Input.GetKeyUp(KeyCode.Space)) { SpaceLift = true; Animator2d.SetBool("isJump", false); }


        // movement is up, jump is down 


    }


    void FixedUpdate()
    {
       // Vector2 movement = new Vector2(RawInput,0);
     //   Rg.velocity = movement * speed;
        Rg.AddForce(( RawInput * Time.deltaTime * speed * Vector2.right), ForceMode2D.Impulse);
        Rg.velocity = new Vector2(Mathf.Clamp(Rg.velocity.x, -maxVelo, maxVelo), Rg.velocity.y);
        if (Mathf.Abs(RawInput) > 0) { Animator2d.SetBool("isWalk", true); } else { Animator2d.SetBool("isWalk", false); }
        if (RawInput < 0) { transform.localScale = new Vector3(-3.5f, 3.5f, 1); Static.LookingRight = false; } else if (RawInput > 0) { transform.localScale = new Vector3(3.5f, 3.5f, 1); Static.LookingRight = true; }

        if (SpaceHold) { Fallspeed = Fallmult - 1.5f; SpaceHold = false; } else { Fallspeed = Fallmult; }
        if (grounded() || enemy()) { coyoteTimer = coyoteBase; } else { coyoteTimer = coyoteTimer - Time.deltaTime; Rg.velocity = new Vector2(Rg.velocity.x, Rg.velocity.y + (Physics2D.gravity.y * (Fallspeed - 1) * Time.deltaTime)); }

        if (spaceClick) { JumpBufferTimer = JumpBase; spaceClick = false; }
        else
        {
            JumpBufferTimer -= Time.deltaTime;
            if (JumpBufferTimer > 0f && coyoteTimer > 0f) { Rg.velocity = new Vector2(Rg.velocity.x, 0); Jump(); JumpBufferTimer = 0; }
            if (SpaceLift & Rg.velocity.y > 0) { coyoteTimer = 0; SpaceLift = false; }

        }
    }
    bool enemy()
    {
        float extra = 0.1f;
        RaycastHit2D hit2 = Physics2D.BoxCast(boxer.bounds.center, boxer.bounds.size, 0f, Vector2.down, extra, enemymask);
        if (hit2.collider != null) { GameObject.Destroy(hit2.collider.gameObject); }
        if (hit2.collider != null) { return true; } else { return false; }
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
