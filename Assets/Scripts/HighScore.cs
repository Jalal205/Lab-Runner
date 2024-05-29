using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScore; // This is the global variable known as highscore

    void Start()
    {
        DisplayHS(); // This calls the function DisplayHS in the start of the Main Menu
    }


    public static void checkHS() // This is a function which checks if the Score is higher than the Highscore
    {
        if(PlayerManager.currentTime > PlayerPrefs.GetInt("HighScore", 0)) // This checks if the Score is higher than the Highscore
        {
            PlayerPrefs.SetInt("HighScore", (int) PlayerManager.currentTime); // This then changes the HighScore if the score is higher than the Highscore
        }
    }

    public void DisplayHS() // This allows the Highscore to be Displayed
    {
        highScore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}"; // This writes the text in the game using PlayerPrefs which stores the Highscore
    }
}
