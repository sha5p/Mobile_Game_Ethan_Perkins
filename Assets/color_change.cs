using UnityEngine;

public class color_change : MonoBehaviour
{
    public Color newColor = Color.red;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("this si the change colour script");

        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        
        foreach (Renderer renderer in renderers)
        {
            
            renderer.material.color = newColor;
        }
        color_Change_func();
    }

    public void color_Change_func()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        string colorName  = PlayerPrefs.GetString("MyColor");
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
        foreach (Renderer renderer in renderers) 
        {
            renderer.material.color = newColor;
        }
    }
}

