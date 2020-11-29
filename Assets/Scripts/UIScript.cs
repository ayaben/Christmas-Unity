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

    public void IntroGame1()
    {
        SceneManager.LoadScene("Intro1");
    }

    public void IntroGame2()
    {
        SceneManager.LoadScene("Intro2");
    }

    public void IntroGame3()
    {
        SceneManager.LoadScene("Intro3");
    }

    public void IntroGame4()
    {
        SceneManager.LoadScene("Intro4");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Jeu");
    }
  
}
