using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Contiue : MonoBehaviour
{

    [SerializeField] private GameObject Canvas;

    [SerializeField] private TextMeshProUGUI currentTime;

    public Timer time_script;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void contiue()
    {
        Selection_Level.currLevel += 1;
        Debug.Log(Selection_Level.currLevel+ "Current level");
        SceneManager.LoadScene(Selection_Level.currLevel+1);
        

    }
    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }
    public void nextlevel()
    {

        if (Selection_Level.currLevel == Selection_Level.UnlockedLevel)
        {
            Selection_Level.UnlockedLevel++;
            Debug.Log(Selection_Level.UnlockedLevel + "This is the selection level");
            PlayerPrefs.SetInt("UnlockedLevel", Selection_Level.UnlockedLevel);
        }
        else
        {
            Debug.Log("Glitch");
        }

        //contiue.onClick.AddListener(ChangeScene);
        int minutes = Mathf.FloorToInt(time_script.elaspedtime / 60);
        int seconds = Mathf.FloorToInt(time_script.elaspedtime % 60);
        int milliseconds = Mathf.FloorToInt((time_script.elaspedtime * 1000) % 1000);
        currentTime.text = "Time" +  minutes + ":" + seconds;


        Canvas.gameObject.SetActive(true);

    }

}
