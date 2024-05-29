using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{

    public void RestartGame() // This is a new method that can be called in the on click events which restarts the Scene(Level)
    {
        SceneManager.LoadScene("Level"); // This then loads the scene by the name "Level", which is the game in running state
    }

    public void QuitGame() // This makes a new method that can also be called in the on click events which closes the game
    {
        Application.Quit(); // This closes the game
    }
}
