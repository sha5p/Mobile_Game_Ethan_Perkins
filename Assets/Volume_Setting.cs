using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
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
    public void OnClickBack()
    {
        stickman.SetActive(true);
        anachor.SetActive(true);
        string_web.SetActive(true);
        swiper.SetActive(true);
        main_menu.SetActive(true);
        levels.SetActive(false);
        music_settings.SetActive(false);
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
