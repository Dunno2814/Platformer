using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed;
    public float time;
    private void Start()
    {
        
    }
    void Update()
    {
        
        transform.Rotate(0,0, 1 * Time.deltaTime * speed) ;
        time = time + Time.deltaTime;
        
        
    }
}
