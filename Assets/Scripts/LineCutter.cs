using UnityEngine;

public class LineCutter : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
        if (toggle_script_setting.control_mobile == 1) 
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            gameObject.SetActive(false);
        }
        else 
        {
            gameObject.SetActive(true);
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
