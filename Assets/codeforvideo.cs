using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class codeforvideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(videoPlayer.frameCount);
        Debug.Log(videoPlayer.frame);
        if (videoPlayer.frame == 46)
       {
            GameObject.Destroy(gameObject);
            panel.SetActive(true);
       }
    }
}
