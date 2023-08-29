using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
    
{
    public GameObject player;
    public GameObject camObj;
    public Camera cam;
    Vector2 Leftvec;
    Vector2 RightVec;
    void Start()
    {
        camObj = Static.cam;
        cam = camObj.GetComponent<Camera>();
        player = Static.player;
        
    }
    void Update()
    {
        Leftvec = cam.ScreenToWorldPoint(Vector2.zero);
        RightVec = cam.ScreenToWorldPoint(new Vector2 (Screen.width,Screen.height));
        
        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, Leftvec.x + 0.75f, RightVec.x + 0.5f), player.transform.position.y, player.transform.position.z);
    }
}
