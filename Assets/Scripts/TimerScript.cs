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
    void Start()
    {
        startTimer = startTimer + (int) Time.time;
        // TexteTimer.text = "Temps restant  :  " + startTimer; 
        //IEnumerator GameOver() { yield return new WaitForSeconds(startTimer = 0);SceneManager.GetSceneByName("GAMEOVER"); StartCoroutine(GameOver());}
    }
    private void Update()
    {
            float tempsRestant = startTimer - Time.time;
            print((tempsRestant / 60).ToString());
            TexteTimer.text = "Temps restant  :  " + ((int)(tempsRestant / 60)).ToString()
            + ":" + ((int)(tempsRestant - ((int)(tempsRestant / 60)) * 60)).ToString();

            if(tempsRestant <= 0f){
                SceneManager.LoadScene("GameOver");
            }


    }

}
