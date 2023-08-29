using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    Rigidbody2D Rg;
    public float speed, maxVelo;
    private void Start()
    {
        Rg = gameObject.GetComponent<Rigidbody2D>();
        speed = 50f;
        maxVelo = 40f;
        Static.LookingRight = true;
    }
    void Update()
    {
        Rg.AddForce((Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed * Vector2.right), ForceMode2D.Impulse);
        Rg.velocity = new Vector2(Mathf.Clamp(Rg.velocity.x, -maxVelo, maxVelo), Rg.velocity.y);
        if (Input.GetAxisRaw("Horizontal") < 0) { transform.localScale = new Vector3(-1.5f, 1.5f, 1); Static.LookingRight = false; } else if (Input.GetAxisRaw("Horizontal") > 0) { transform.localScale = new Vector3(1.5f, 1.5f, 1); Static.LookingRight = true; }

    }

}
