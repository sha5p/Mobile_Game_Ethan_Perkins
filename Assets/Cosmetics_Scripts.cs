using UnityEngine;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Cosmetics_Scripts : MonoBehaviour
{
    public TextMeshProUGUI output;

    public GameObject skin_cosmetics;
    public GameObject skin_cosmetics_exit;


    public string colorKey;

    public color_change color_change_script;

    public  TMP_Dropdown colorDropdown;

    public LineCutter swipe_script;

    public TMP_Dropdown swipeDropdown;

    public UnityEngine.UI.Button button_player_skin;

    private int coinCount;
    [SerializeField] private TextMeshProUGUI coinTotal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        for (int i = 0; i <= 12; i++) // Loop from scene "0" to "12"
        {
            int sceneCoins = PlayerPrefs.GetInt(i.ToString() + "CollectedCoins", 0); // Get the coins for this scene
            coinCount = coinCount + sceneCoins; // Add the coins to the total
        }

        coinTotal.text = "Total Coins: " + coinCount.ToString();
        skin_cosmetics.SetActive(false);
        string colorName = PlayerPrefs.GetString("MyColor");
        
        if (coinCount < 1)
        {
            colorDropdown.interactable = false;
        }
        if (coinCount < 3)
            {
            swipeDropdown.interactable = false;
            }
        if (coinCount < 6)
        {
            button_player_skin.interactable = false;
        }
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

        string colorName_swipe = PlayerPrefs.GetString("MyColor_swipe");
        if (string.IsNullOrEmpty(colorName_swipe))
        {
            swipeDropdown.value = 0;
        }
        else if (colorName_swipe == "red")
        {
            swipeDropdown.value = 1;
        }
        else if (colorName_swipe == "green")
        {
            swipeDropdown.value = 2;
        }
        else if (colorName_swipe == "pink")
        {
            swipeDropdown.value = 3;
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
    public void HandleInputData_2(int val)
    {

        if (1 == 1)
        {
            if (val == 0)
            {
                PlayerPrefs.SetString("MyColor_swipe", "white");
                PlayerPrefs.Save();
                Debug.Log("Skin change to white");
                swipe_script.color_Change_func();
            }
            if (val == 1)
            {
                PlayerPrefs.SetString("MyColor_swipe", "red");
                PlayerPrefs.Save();
                Debug.Log("Skin change to red");
                swipe_script.color_Change_func();
            }
            if (val == 2)
            {
                PlayerPrefs.SetString("MyColor_swipe", "green");
                PlayerPrefs.Save();
                swipe_script.color_Change_func();
            }
            if (val == 3)
            {
                PlayerPrefs.SetString("MyColor_swipe", "pink");
                PlayerPrefs.Save();
                Debug.Log("Skin change to pink for swipe");
                swipe_script.color_Change_func();
            }
        }

    }
    
    public void clicked_Shop()
    {
        skin_cosmetics.SetActive(true);
    }
    public void clicked_exit_Skinshop()
    {
        skin_cosmetics.SetActive(false);
    }
}
