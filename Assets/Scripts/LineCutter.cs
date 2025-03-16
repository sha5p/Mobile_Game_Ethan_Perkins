using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LineCutter : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    CircleCollider2D circleCollider;
    public Color newColor = Color.white;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        color_Change_func();
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
    public void color_Change_func()
    {
        TrailRenderer trailRenderer = GetComponent<TrailRenderer>();
        string colorName = PlayerPrefs.GetString("MyColor_swipe");
        if (colorName == "red")
        {
            newColor = Color.red;
        }
        else if (colorName == "blue")
        {
            newColor = Color.blue;
        }
        else if (colorName == "green")
        {
            newColor = Color.green;
        }
        else if (colorName == "white")
        {
            newColor = Color.white;
        }
        else if (colorName == "pink")
        {
            newColor = new Color(1, 0, 0.8f, 1);
        }
        trailRenderer.startColor = newColor;
        trailRenderer.endColor = newColor;
    }
}
