using UnityEngine;
using TMPro; // Important! Add this line to use TextMeshPro

public class script : MonoBehaviour
{
    public TMP_Text coinCountText; // Assign your TextMeshPro object here in the inspector

    void Start() // Use Start() to run the code when the object is created
    {
        int coinCount = 0; // Initialize coinCount

        for (int i = 0; i <= 12; i++)
        {
            int sceneCoins = PlayerPrefs.GetInt(i.ToString() + "CollectedCoins", 0);
            coinCount = coinCount + sceneCoins;
        }

        if (coinCountText != null) // Check if the TextMeshPro object is assigned
        {
            coinCountText.text = "Total Coins: " + coinCount.ToString(); // Set the text
        }
        else
        {
            Debug.LogError("CoinCountText is not assigned! Please assign it in the inspector.");
        }
    }
}