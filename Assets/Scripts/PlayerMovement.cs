using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Gestion de la vitesse du player
    public float vitesse;
    public float vitesseInitiale;
    public float vitesseMax;
    public float dureeAcceleration = 5f;
    float tempsAcceleration = 0;

    // Gestion de la vitesse de la musique de fond
    public AudioSource musique;
    public PauseScript monScriptPause;

    void Start()
    {
        musique.pitch = 1f;
    }

    void Update()
    {
        if (!monScriptPause.Paused) // Si le bouton pause est enfoncé, le player ne bouge pas
        {
            tempsAcceleration += Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-vitesse, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(vitesse, 0, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -vitesse, 0);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, vitesse, 0);
            }

            if (vitesse == vitesseMax)
            {
                UpdateVitesse();
            }

        }
    }



    public void Acceleration()
    {
        vitesse = vitesseMax;
        tempsAcceleration = 0;
        // Accélération du fond musical 
        musique.outputAudioMixerGroup.audioMixer.SetFloat("musiquePitch", 1.3f);
        musique.outputAudioMixerGroup.audioMixer.SetFloat("pitchShifter", 0.7f);
    }

    void UpdateVitesse()
    {
        if (tempsAcceleration >= dureeAcceleration)
        {
            vitesse = vitesseInitiale;
            // Reprise du fond musical à vitesse normale
            musique.outputAudioMixerGroup.audioMixer.SetFloat("musiquePitch", 1f);
            musique.outputAudioMixerGroup.audioMixer.SetFloat("pitchShifter", 1f);
        }
    }
}