using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject desire;
    public GameObject cam;
    public Camera Ccam;
    public GameObject bulletprefab, spawn;
    public int size = 0;
    public Animator Animator2d;
    void Start()
    {
        cam = Static.cam;
        Ccam = cam.GetComponent<Camera>();
        spawn = GameObject.FindGameObjectWithTag("LineStart");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0) & Static.canShoot) { GameObject.Instantiate(bulletprefab, spawn.transform.position, new Quaternion (0,0,0,0)); Animator2d.SetBool("isShoot", true);  }
        else if (Input.GetMouseButtonUp(0)) { Animator2d.SetBool("isShoot", false); }
    }
}
