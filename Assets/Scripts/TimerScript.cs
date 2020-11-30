using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    int startTimer = 180;

    [SerializeField]
    Text TexteTimer;

    public AudioSource tempsFinal;


    void Start()
    {
        startTimer = startTimer + (int) Time.time;
        Invoke("playFinalCountdown", 170.0f);
    }

    private void Update()
    {
        float tempsRestant = startTimer - Time.time;
        print((tempsRestant / 60).ToString());

        TexteTimer.text = "Temps restant  :  " + ((int)(tempsRestant / 60)).ToString()
        + ":" + ((int)(tempsRestant - ((int)(tempsRestant / 60)) * 60)).ToString();

        PlayerPrefs.SetString("TempsFinal", "Temps de jeu : " + ((int)(3-(tempsRestant / 60))).ToString() 
            + ":" + (60-((int)(tempsRestant - ((int)(tempsRestant / 60)) * 60))).ToString());


        if (tempsRestant <= 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }

    void playFinalCountdown()
    {
        tempsFinal.Play();
    }


    

}
