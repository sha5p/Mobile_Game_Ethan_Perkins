using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject contiue;
    public static bool pause;
    public void PauseGame()
    {
        if (!contiue.activeSelf)
        {
            pause = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void Unpause_Game()
    {
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
