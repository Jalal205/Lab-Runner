using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class sceneSwitcher : MonoBehaviour
{
    public void LoadScene(string sceneName)//It makes a sceneName and gives it the string data type
    {
        SceneManager.LoadScene(sceneName); //Switches to the scene put in the inspector
    }
}