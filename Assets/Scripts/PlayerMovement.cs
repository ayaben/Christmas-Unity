using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float vitesse;
    public float vitesseInitiale;
    public float vitesseMax;
    public float dureeAcceleration = 5f;
    float tempsAcceleration = 0;
    public PauseScript monScriptPause;

    void Start ()
	{

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
    }

    void UpdateVitesse()
    {
        if (tempsAcceleration >= dureeAcceleration)
        {
            vitesse = vitesseInitiale;
        }
    }
}