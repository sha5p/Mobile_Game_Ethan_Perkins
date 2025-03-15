using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LineCutter : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    CircleCollider2D circleCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(toggle_script_setting.control_mobile+ "This is a checker script");
        if (((Input.touchCount > 0) &&Pause_Menu.pause==false) && toggle_script_setting.control_mobile == 0)
        {
            circleCollider.enabled = true;
            
            
            gameObject.SetActive(true);
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            Touch touch = Input.GetTouch(0);
            Vector2 worldTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = worldTouchPosition;
        }
        else
        {
            circleCollider.enabled = false;
            
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

    }
}
