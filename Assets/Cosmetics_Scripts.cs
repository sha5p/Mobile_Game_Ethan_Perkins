using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Cosmetics_Scripts : MonoBehaviour
{
    public TextMeshProUGUI output;


    public string colorKey;

    public color_change color_change_script;

    public  TMP_Dropdown colorDropdown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        string colorName = PlayerPrefs.GetString("MyColor");
        if (string.IsNullOrEmpty(colorName))
        {
            colorDropdown.value = 0;
        }
        else if (colorName == "red")
        {
            colorDropdown.value = 1;
        }
        else if (colorName == "green")
        {
            colorDropdown.value = 2;
        }
        else if (colorName == "pink")
        {
            colorDropdown.value = 3;
        }
    }
    public void HandleInputData(int val)
    {
        
        if (1 == 1)
        {
            if (val==0)
            {
                PlayerPrefs.SetString("MyColor", "white");
                PlayerPrefs.Save();
                Debug.Log("Skin change to white");
                color_change_script.color_Change_func();
            }
            if (val == 1)
            {
                PlayerPrefs.SetString("MyColor", "red");
                PlayerPrefs.Save();
                Debug.Log("Skin change to red");
                color_change_script.color_Change_func();
            }
            if (val == 2)
            {
                PlayerPrefs.SetString("MyColor", "green");
                PlayerPrefs.Save();
                color_change_script.color_Change_func();
            }
            if (val == 3)
            {
                PlayerPrefs.SetString("MyColor", "pink");
                PlayerPrefs.Save();
                Debug.Log("Skin change to pink");
                color_change_script.color_Change_func();
            }
        }
        
    }
}
