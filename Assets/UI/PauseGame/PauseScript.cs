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
    AudioSource[] sources;

    void Start()
    {
        BoutonPause.GetComponent<Button>();
        sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }


    public void pauseGame()
    {
        if (Paused)
        {
            BoutonPause.image.overrideSprite = ImagePause;
            Time.timeScale = 1;
            Mute(false);
            Muted = true;
            Paused = false;
        }
        else
        {
            BoutonPause.image.overrideSprite = ImagePlay;
            Time.timeScale = 0;
            Mute(true);
            Muted = false;
            Paused = true;
        }
    }


    void Mute(bool sons)
    {
        foreach (AudioSource tousSons in sources)
        {
            tousSons.volume = sons ? 0 : 1;
        }
    }
}
