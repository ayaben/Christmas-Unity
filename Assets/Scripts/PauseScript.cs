using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]

public class PauseScript : MonoBehaviour
{
    public bool Paused = false;
    public bool Muted = false;
    public Button BoutonPause;
    public Sprite ImagePause;
    public Sprite ImagePlay;
    public MuteScript scriptMute;

    void Start()
    {
        BoutonPause.GetComponent<Button>();
    }


    public void pauseGame()
    {
        if (Paused)
        {
            BoutonPause.image.overrideSprite = ImagePause;
            Time.timeScale = 1;
            if (scriptMute.Muted == true)
            {
             AudioListener.volume = 1f;
             Muted = true;
           }
            Paused = false;
        }
        else
        {
            BoutonPause.image.overrideSprite = ImagePlay;
            Time.timeScale = 0;
           
                 AudioListener.volume = 0f;
                Muted = false;
            
            
           
            Paused = true;
        }
    }
}
