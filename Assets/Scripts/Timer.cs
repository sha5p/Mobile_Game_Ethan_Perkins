using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    public float elaspedtime;
    public Player_Script playerScript;
    // Update is called once per frame
    void Update()
    {
        if (playerScript.won == false)
        {
            elaspedtime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elaspedtime / 60);
            int seconds = Mathf.FloorToInt(elaspedtime % 60);
            int milliseconds = Mathf.FloorToInt((elaspedtime * 1000) % 1000);
            timeText.text = "Time: " + minutes + ":" + seconds;
        }
       
    }
}
