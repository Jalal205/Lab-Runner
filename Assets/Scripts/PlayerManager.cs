using UnityEngine;
using UnityEngine.UI; // I had to use this library so that i could change the text in unity
using TMPro; // I had to use this library so that i could change the text in unity

public class PlayerManager : MonoBehaviour
{
    public static bool GameOver; // This is a global variable that can be accessed from other scripts is also a boolean
    public GameObject GameOverPanel; // This is made so that the GameOver can be referenced

    public static int coinCounter; // This is the coin counter tracking the amount of coins collected
    public TextMeshProUGUI coinsText; // This is a variable to reference the text in coinsText

    public TextMeshProUGUI scoreText; // This is a variable to reference the text in scoreText
    public static float currentTime; // This allows us to set the number at which the score starts which is 0

    void Start()
    {
        GameOver = false; // This sets the boolean default to false
        Time.timeScale = 1; // This needs to be added so that when the restart button is clicked the game isnt frozen
        coinCounter = 0; // This sets the coin counter to start of by 0 as default
        currentTime = 0f; // This resets the score everytime a new game is started
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver) // Checks if game is over if so it stops the game
        {
            Time.timeScale = 0; // This stops the game if the game is over
            GameOverPanel.SetActive(true); // This then activiates the game over panel when the game is over
        }
        coinsText.text = "Coins: " + coinCounter; // This changes the text in coin text by adding the coinCounter to it by each frame

        currentTime = currentTime += Time.deltaTime; // This adds time to the currentTime if countUp is True
        HighScore.checkHS();
        scoreText.text = "Score: " + currentTime.ToString("0"); // This then changes the text in score text by adding the currentTome to it by each frame
    }                                           // ToString("0") allows it to only display the whole number not the decimals
}
