using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager_script : MonoBehaviour
{
    [SerializeField] private GameObject finishLine;
    [SerializeField] private Camera_Follow camera_Follow;
    [SerializeField] private Player_Script player_Script;

    [SerializeField] private GameObject Coin_Gameobject;
    [SerializeField] private GameObject player;
    Audio_Manager audio_manager;

    private bool won;
    private float sppedOnWin;
    private Vector3 initPos;


    public int coinCount;
    public static int Saved_coinscount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        audio_manager= GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    void Start()
    {


        string sceneName = SceneManager.GetActiveScene().name;
        Saved_coinscount = PlayerPrefs.GetInt(sceneName+"CollectedCoins", 0);
        if (Saved_coinscount >= 1)
        {
            Destroy(Coin_Gameobject);
        }
        for (int i = 0; i <= 12; i++) // Loop from scene "0" to "12"
        {
            int sceneCoins = PlayerPrefs.GetInt(i.ToString() + "CollectedCoins", 0); // Get the coins for this scene
            coinCount = coinCount + sceneCoins; // Add the coins to the total
        }
        Debug.Log(finishLine);
        player_Script = player_Script.GetComponent<Player_Script>();
        initPos= player_Script.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_Script.getSticked()==false)
        {
            if(player.transform.position.x < -5)
            {
                Debug.Log("dawdawdawdad");
                ResetGame();
            }
            if (player.transform.position.y < -6)
            {
                Debug.Log("dawdawdawdad");
               ResetGame();
            }
        }
        
        if (finishLine.transform.position.x < player.transform.position.x && !won)
        {
            Debug.Log("you win ig");
            won = true;
            Win();
        }
    }
    private void ResetGame()
    {
        audio_manager.PlaySFX(audio_manager.death);
        player_Script.reset(initPos);

    }
    private void Win()
    {
        camera_Follow.Win();
        player_Script.win(sppedOnWin);

        //StartCoroutine(FinishLevel());
    }
    //IEnumerator FinishLevel()
    //{
        //Debug.Log("yk");
        //SceneManager.LoadScene(0);
    //}
}
