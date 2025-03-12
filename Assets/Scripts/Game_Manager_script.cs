using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager_script : MonoBehaviour
{
    [SerializeField] private GameObject finishLine;
    [SerializeField] private Camera_Follow camera_Follow;
    [SerializeField] private Player_Script player_Script;

    [SerializeField] private GameObject player;
    

    private bool won;
    private float sppedOnWin;
    private Vector3 initPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
