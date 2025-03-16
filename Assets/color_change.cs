using UnityEngine;

public class color_change : MonoBehaviour
{
    public Color newColor;
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
        string colorName = PlayerPrefs.GetString("MyColor");
        Debug.Log(colorName);
        if (colorName == "red")
        {
            newColor = Color.red;
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = newColor;
            }
        }
        else if (colorName == "blue")
        {
            newColor = Color.blue;
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = newColor;
            }
        }
        else if (colorName == "green")
        {
            newColor = Color.green;
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = newColor;
            }
        }
        else if (colorName == "white")
        {
            newColor = Color.white;
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = newColor;
            }
        }
        else if (colorName == "pink")
        {
            newColor = new Color(1, 0, 0.8f, 1);
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = newColor;
            }
        }
        else
        {
            string colorString = PlayerPrefs.GetString("MyColor");

            Debug.Log(colorName + "This shold not be 00000");
            string[] z = colorString.Split(',');

            Debug.Log(z[0]+ "This should be the z value");
            string[] colorValues = colorString.Split(',');
            Debug.Log(colorString + "Color Values" + colorValues);
            float r = float.Parse(colorValues[0]);
            float g = float.Parse(colorValues[1]);
            float b = float.Parse(colorValues[2]);
            float a = float.Parse(colorValues[3]);
            Debug.Log($"Parsed values: r={r}, g={g}, b={b}, a={a}");
            Color loadedColor = new Color(r, g, b, a);
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = loadedColor;
            }
        }
    }
    public void color_EqualRenderer()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        newColor = meshRenderer.material.color;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        
        string colorString = $"{newColor.r.ToString("F4")},{newColor.g.ToString("F4")},{newColor.b.ToString("F4")},{newColor.a.ToString("F4")}";
        Debug.Log(colorString + "CADADADAD" + "This shuold be" + newColor);
        if (colorString != "0.0000,0.0000,0.0000,1.0000")
        {
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = newColor;
            }
            Debug.Log("This is occuring saving now");
            PlayerPrefs.SetString("MyColor", colorString);
            PlayerPrefs.Save();
        }
        
    }
}

