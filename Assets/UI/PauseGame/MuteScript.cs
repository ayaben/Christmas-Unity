using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteScript : MonoBehaviour
{
    public Button BoutonMute;
    public Sprite SoundOFF, SoundON;
    public bool Muted = false;
    private float volumeInitial;
    AudioListener tousSons;
    

    void Start()
    {
        BoutonMute.GetComponent<Button>();
    }



    public void MuteMusic()
    {
        if (Muted)
        {
            BoutonMute.image.overrideSprite = SoundOFF;
            AudioListener.volume = 0f;
            Muted = false;
        }
        else
        {
            BoutonMute.image.overrideSprite = SoundON;
            AudioListener.volume = 1f;
            Muted = true;
        }
    }

}
