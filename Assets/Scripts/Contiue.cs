using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Contiue : MonoBehaviour
{

    [SerializeField] private GameObject Canvas;

    [SerializeField] private TextMeshProUGUI currentTime;

    [SerializeField] private TextMeshProUGUI coinTotal;

    public Timer time_script;

    Audio_Manager audio_manager;

    private Game_Manager_script coins;
    private int coinCount;
    private void Awake()
    {
        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coins = GameObject.Find("GameManager").GetComponent<Game_Manager_script>();
        string currentSceneName = SceneManager.GetActiveScene().name;
        Selection_Level.currLevel = int.Parse(currentSceneName)-1;
        Canvas.gameObject.SetActive(false);
        if (currentSceneName == "11") 
        {
            Canvas.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void contiue()
    {
        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
        Selection_Level.currLevel += 1;
        Debug.Log(Selection_Level.currLevel+ "Current level");
        SceneManager.LoadScene(Selection_Level.currLevel+1);
        

    }
    public void home()
    {
        audio_manager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
        Time.timeScale = 1f;

        SceneManager.LoadScene("Main_Menu");
    }
    public void nextlevel()
    {
        Debug.Log(Selection_Level.currLevel);

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
        currentTime.text = "Time " +  minutes + ":" + seconds;

        
        for (int i = 0; i <= 12; i++) // Loop from scene "0" to "12"
        {
            int sceneCoins = PlayerPrefs.GetInt(i.ToString() + "CollectedCoins", 0); // Get the coins for this scene
            coinCount = coinCount + sceneCoins; // Add the coins to the total
        }
        coinTotal.text = "Total Coins: "+coinCount.ToString();


        Canvas.gameObject.SetActive(true);

    }

}
