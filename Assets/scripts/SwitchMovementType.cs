using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwitchMovementType : MonoBehaviour
{
    RaycastHit2D left, right;
    public float distanceLeft, distanceRight;
    public LayerMask interactive;
    public float yfix;
    public GameObject player;
    public float distanceX;
    public Vector2 transfo, Rright;
    void Start()
    {
        distanceRight = Static.EnemyRayDis;
        distanceLeft = Static.EnemyRayDis;
        yfix = 0.5f;
        player = Static.player;
        Rright = new Vector2(transform.right.x, transform.right.y);
    }


    void FixedUpdate()
    {
        transfo = new Vector2(transform.position.x, transform.position.y);

        rayAction();
        distanceX = transform.position.x - right.point.x;
    }
    void rayAction()
    {
        right = Physics2D.Raycast( transfo - Vector2.down * yfix, Vector2.right,distanceRight, interactive);
        if (right.collider != null) {  Debug.Log(right.collider); } else if (left.collider != null) { Debug.Log(left.collider); }
        //if (right.collider.gameObject != null) { if (right.collider.gameObject == player) { Debug.Log("debug hi player"); } }
        Debug.DrawLine(transfo + Vector2.down * yfix, transfo + (Rright * distanceLeft) + Vector2.down * yfix);
        left = Physics2D.Raycast(transfo - Vector2.down * yfix, Vector2.left, distanceLeft, interactive);
        //if (left.collider.gameObject != null) { if (right.collider.gameObject == player) { Debug.Log("debug hi player"); } }
        Debug.DrawLine(transfo + Vector2.down * yfix, transfo - (Rright * distanceLeft) + Vector2.down * yfix);
    }
}
