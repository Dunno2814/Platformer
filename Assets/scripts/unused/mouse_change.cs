using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_change : MonoBehaviour
{
    public Texture2D HandMouse, SlingMouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        Debug.Log("Over");
        Cursor.SetCursor(SlingMouse, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Debug.Log("Exit");
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
