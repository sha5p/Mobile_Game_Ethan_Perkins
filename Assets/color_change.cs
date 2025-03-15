using UnityEngine;

public class color_change : MonoBehaviour
{
    public Color newColor = Color.red;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        // Loop through each renderer
        foreach (Renderer renderer in renderers)
        {
            // Change the Albedo color of the material
            renderer.material.color = newColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
