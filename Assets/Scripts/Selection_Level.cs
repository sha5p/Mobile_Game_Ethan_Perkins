using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
public class Selection_Level : MonoBehaviour
{
    [SerializeField] private GameObject swiper;
    [SerializeField] private GameObject stickman;
    [SerializeField] private GameObject anachor;
    [SerializeField] private GameObject string_web;
    [SerializeField] private GameObject main_menu;
    [SerializeField] private GameObject levels;


    public Button_Level[] levelObjects;



    public static int UnlockedLevel;
    public static int currLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        //PlayerPrefs.DeleteAll();
        UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel",0);
        for(int i = 0; i < levelObjects.Length; i++)
        {
            Debug.Log(UnlockedLevel);
            if (UnlockedLevel >=i)
            {
                levelObjects[i].levelButton.interactable = true;
            }
        }

        this.gameObject.SetActive(false);

    }
    public void OnClickBack()
    {
        stickman.SetActive(true);
        anachor.SetActive(true);
        string_web.SetActive(true);
        swiper.SetActive(true);
        main_menu.SetActive(true);
        levels.SetActive(false);
    }

    public void OnClickLevel(int levelNum)
    {
        currLevel = levelNum;
        SceneManager.LoadScene(currLevel+1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
