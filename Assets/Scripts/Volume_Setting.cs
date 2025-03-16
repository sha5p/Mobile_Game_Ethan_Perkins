using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Volume_Setting : MonoBehaviour
{
    [Header("Mixers")]
    [SerializeField] private AudioMixer Mixer;


    [Header("Sliders")]
    [SerializeField] private Slider Masterslider;
    [SerializeField] private Slider SFX_slider;
    [SerializeField] private Slider Musicslider;



    [Header("Menu Checks")]
    [SerializeField] private GameObject swiper;
    [SerializeField] private GameObject stickman;
    [SerializeField] private GameObject anachor;
    [SerializeField] private GameObject string_web;
    [SerializeField] private GameObject main_menu;
    [SerializeField] private GameObject levels;
    [SerializeField] private GameObject music_settings;


    [Header("Game_Checks")]
    [SerializeField] private GameObject pause_Text;
    [SerializeField] private GameObject pause;

    Audio_Manager audio_manager;

    public void newSave()
    {

        string currentSceneName = SceneManager.GetActiveScene().name;
        
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("MyColor", "white");
        PlayerPrefs.SetString("MyColor_swipe", "white");
        SceneManager.LoadScene(currentSceneName);

    }
    private void Awake()
    {

        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();

    }
    public void OnClickBack()
    {

        audio_manager.PlaySFX(audio_manager.ClickSound);
        string currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName == "Main_Menu")
        {
            // If it is "mainmenu", activate the game objects
            stickman.SetActive(true);
            anachor.SetActive(true);
            string_web.SetActive(true);
            swiper.SetActive(true);
            main_menu.SetActive(true);
            levels.SetActive(false);
        }
        else
        {
            pause.SetActive(true);
            pause_Text.SetActive(true);
        }
        music_settings.SetActive(false);
    }
    public void OnMusicClicked()
    {
        audio_manager.PlaySFX(audio_manager.ClickSound);
        pause.SetActive(false);
        pause_Text.SetActive(false);
        music_settings.SetActive(true);
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
        }
        else 
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
        this.gameObject.SetActive(false);
    }

    private void LoadVolume()
    {
        Masterslider.value = PlayerPrefs.GetFloat("MasterVolume");
        SFX_slider.value = PlayerPrefs.GetFloat("SFXVolume");
        Musicslider.value = PlayerPrefs.GetFloat("MusicVolume");
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }
    public void SetMasterVolume()
    {
        float volume = Masterslider.value;
        Mixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MasterVolume",volume);
    }
    public void SetSFXVolume()
    {
        float volume = SFX_slider.value;
        Mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    public void SetMusicVolume()
    {
        float volume = Musicslider.value;
        Mixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }


}
