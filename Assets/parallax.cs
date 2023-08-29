using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class parallax : MonoBehaviour
{
    GameObject camObj;
    Camera cam;
    public float parallaxFactor;
    float length, StartPos;
    void Start()
    {
        StartPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        camObj = Static.cam;
        cam = camObj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = cam.transform.position.x * parallaxFactor;
        Vector3 newPosition = new Vector3(StartPos + distance, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
