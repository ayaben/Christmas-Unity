using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
   public void QuitGame()
    {
        Application.Quit();
    }

    public void IntroGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Jeu");
    }
  
}
