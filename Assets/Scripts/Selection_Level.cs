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
    [SerializeField] private GameObject music_settings;

    public Button_Level[] levelObjects;



    public static int UnlockedLevel;
    public static int currLevel;

    Audio_Manager audio_manager;
    private void Awake()
    {
        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Debug.Log("levelObjects array size: " + levelObjects.Length);
        //PlayerPrefs.DeleteAll();
        UnlockedLevel = PlayerPrefs.GetInt("UnlockedLevel",0);
        
        for(int i = 0; i < levelObjects.Length; i++)
        {
            Debug.Log(UnlockedLevel+ "This is the i" +i);
            if (UnlockedLevel >=i)
            {
                levelObjects[i].levelButton.interactable = true;
            }
        }

        this.gameObject.SetActive(false);

    }
    public void OnClickBack()
    {
        audio_manager.PlaySFX(audio_manager.ClickSound);
        stickman.SetActive(true);
        anachor.SetActive(true);
        string_web.SetActive(true);
        swiper.SetActive(true);
        main_menu.SetActive(true);
        music_settings.SetActive(false);
        levels.SetActive(false);
    }

    public void OnClickLevel(int levelNum)
    {
        audio_manager.PlaySFX(audio_manager.ClickSound);
        currLevel = levelNum;
        SceneManager.LoadScene(currLevel+1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
