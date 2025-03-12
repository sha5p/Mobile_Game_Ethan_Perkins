using UnityEngine;

public class LineCutter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0)&&Pause_Menu.pause==false)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 worldTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = worldTouchPosition;
        }
    }
}
