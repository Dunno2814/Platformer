using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_fake : MonoBehaviour
{
    float timer, dir, animationSpeed;
    void Start()
    {
        dir = 1;
        timer = 0;
        animationSpeed = 4;
    }
    void Update()
    {
        timer = timer + (Time.deltaTime * dir * animationSpeed);
        if ( timer > 1) dir = -1;
        if (timer < -1) dir = 1;
        transform.eulerAngles = new Vector3(0, 0, timer * 15f);
    }
}
