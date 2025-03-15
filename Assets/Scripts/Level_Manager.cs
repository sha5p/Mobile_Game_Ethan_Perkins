using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Level_Manager : MonoBehaviour
{
   
    [SerializeField] private Canvas Canvas;
    
    [SerializeField] private GameObject stickman;
    [SerializeField] private GameObject anachor;
    [SerializeField] private GameObject string_web;
    [SerializeField] private GameObject main_menu;
    [SerializeField] private GameObject levels;

    [SerializeField] private GameObject swiper;


    [SerializeField] private GameObject music_settings;

    [SerializeField] private GameObject cosmetics;
    Audio_Manager audio_manager;


    private void Awake()
    {

        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    private void Start()
    {
        
    }
    public void OnClickLevel()
    {
        audio_manager.PlaySFX(audio_manager.ClickSound);
        swiper.SetActive(false);
        stickman.SetActive(false);
        anachor.SetActive(false);
        string_web.SetActive(false);
        music_settings.SetActive(false);
        main_menu.SetActive(false);
        levels.SetActive(true);
        
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void music_sett()
    {
        audio_manager.PlaySFX(audio_manager.ClickSound);
        swiper.SetActive(false);
        stickman.SetActive(false);
        anachor.SetActive(false);
        string_web.SetActive(false);
        main_menu.SetActive(false);
        levels.SetActive(false );
        music_settings.SetActive(true);
    }
    // Update is called once per frame
    public void nextlevel()
    {
        audio_manager.PlaySFX(audio_manager.ClickSound);
        Canvas.gameObject.SetActive(false);
        //contiue.onClick.AddListener(ChangeScene);
        Canvas.gameObject.SetActive(true);
    }
}
