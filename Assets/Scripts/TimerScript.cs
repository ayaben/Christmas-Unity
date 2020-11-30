using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    int startTimer = 180; // Jeu de 3 minutes, 180 secondes

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

        //Donne un format "Temps restant : 24:24" à notre timer
        TexteTimer.text = "Temps restant  :  " + ((int)(tempsRestant / 60)).ToString()
        + ":" + ((int)(tempsRestant - ((int)(tempsRestant / 60)) * 60)).ToString();

        // Conserve le temps de jeu pour l'afficher sur la scène de "Win"
        // Inversion du format du timer pour qu'on ne voie plus le temps restant à joeur, mais le temps écoulé depuis le début du jeu
        PlayerPrefs.SetString("TempsFinal", "Temps de jeu : " + ((int)(3-(tempsRestant / 60))).ToString() 
            + ":" + (60-((int)(tempsRestant - ((int)(tempsRestant / 60)) * 60))).ToString());


        if (tempsRestant <= 0f)
        {
            SceneManager.LoadScene("GameOver"); // Si le joueur n'a pas fini de livrer les maisons avant la fin du temps imparti, il perd
        }
        
    }

    void playFinalCountdown()
    {
        tempsFinal.Play();
    }

}
