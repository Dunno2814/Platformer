using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ray : MonoBehaviour
{

    public Vector3 hitp;
    RaycastHit2D hit;
    public Vector3 dis, dir;
    public float length;
    GameObject camObj;
    Camera cam;
    public LayerMask mask;
    GameObject HasLine;
    public LineRenderer line;
    GameObject desired;
    public SpriteRenderer Spri;
    public Vector3 ArmAngle, NegativeArmAngle, scale;
    Vector3 disPlayer;
    public Animator Animator2d;
    public int switch1 = 1;
    void Start()
    {
        camObj = Static.cam;
        cam = camObj.GetComponent<Camera>();
        HasLine = GameObject.FindGameObjectWithTag("Line");
        line = HasLine.GetComponent<LineRenderer>();
        desired = Static.desire;
        Spri = gameObject.GetComponent<SpriteRenderer>();
        ArmAngle = Static.arm.transform.eulerAngles;
        NegativeArmAngle = -1 * Static.arm.transform.eulerAngles;
        disPlayer = Static.arm.transform.position - Static.player.transform.position;
        scale = Static.arm.transform.localScale;
    }


    void Update()
    {
        
        Static.arm.transform.position = Static.player.transform.position +  new Vector3(disPlayer.x * switch1, disPlayer.y, disPlayer.z);
        Static.arm.transform.localScale = new Vector3(1f * switch1, 1f, 1f);
        if (Input.GetMouseButton(1))
        {
            
            myray();
            linedraw(true);
            Animator2d.SetBool("isShoot", true);
            Static.arm.SetActive(true);
            





        }
        else { desired.SetActive(false); Static.canShoot = false; Spri.enabled = false; Static.arm.transform.eulerAngles = Vector3.zero + new Vector3(0,0, 27.38f); Animator2d.SetBool("isShoot", false); line.SetPosition(0, new Vector3(0, 0, 0)); line.SetPosition(1, new Vector3(0, 0, 0)); Static.arm.SetActive(false); }


    }




        
        void myray()
        {
        dis = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        dir = dis.normalized;
        length = new Vector2(dis.x, dis.y).magnitude;
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), dir, 40,mask);
        hitp = new Vector3(hit.point.x, hit.point.y, 0);
        if (Static.LookingRight) { Static.arm.transform.eulerAngles = new Vector3(0, 0, 68.2f); switch1 = 1; }
        if (!Static.LookingRight) { Static.arm.transform.eulerAngles = new Vector3(0, 0, -68.2f); switch1 = -1; ; }
    }
        void linedraw(bool v)
        {
            if (v == true)
            {
                if (hit.point.x != 0) { line.SetPosition(0, transform.position); line.SetPosition(1, hitp); desired.transform.position = hitp; Spri.enabled = true; desired.SetActive(true); Static.canShoot = true; }
                else { line.SetPosition(0, new Vector3(0, 0, 0)); line.SetPosition(1, new Vector3(0, 0, 0)); desired.SetActive(false); Static.canShoot = false; Spri.enabled = false; }
            }
            if (v == false)
            {
                if (hit.point.x != 0) { desired.transform.position = hitp; Spri.enabled = true; desired.SetActive(true); Static.canShoot = true; }
                else { desired.SetActive(false); Static.canShoot = false; Spri.enabled = false; }

            }
        }
    }

