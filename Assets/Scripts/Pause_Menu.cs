using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject contiue;
    public static bool pause;

    Audio_Manager audio_manager;


    private void Awake()
    {
        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    public void PauseGame()
    {
        if (!contiue.activeSelf)
        {
            audio_manager.PlaySFX(audio_manager.ClickSound);
            pause = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void Unpause_Game()
    {
        audio_manager.PlaySFX(audio_manager.ClickSound);
        pause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    void Start()
    {
        pause = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
