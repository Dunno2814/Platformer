using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public GameObject bullet;
    public float timer, timerbase;
    // Start is called before the first frame update
    void Start()
    {
        Static.bulletcount = 0;
    }

    // Update is called once per frame
    private void OnCollisionStay2D(Collision2D collision)
    {
      if(collision.collider.gameObject == Static.player & Static.bulletcount < 3)
        {
            Static.bulletcount = Static.bulletcount + 1;
            Debug.Log("player is here");
            Instantiate(bullet,transform.position, new Quaternion(0,0,0,0));
        }  
    }
}
