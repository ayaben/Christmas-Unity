using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteScript : MonoBehaviour
{
    public Button BoutonMute;
    public Sprite SoundOFF, SoundON;
    public bool Muted = false;

    AudioSource[] sources;


    void Start()
    {
        BoutonMute.GetComponent<Button>();
        sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }



    public void MuteMusic()
    {
        if (Muted)
        {
            BoutonMute.image.overrideSprite = SoundOFF;
            Mute(true);
            Muted = false;
        }
        else
        {
            BoutonMute.image.overrideSprite = SoundON;
            Mute(false);
            Muted = true;
        }
    }

    void Mute (bool sons)
    {
        foreach(AudioSource tousSons in sources)
        {
            tousSons.volume = sons ? 0 : 1 ;
        }
    }

}
