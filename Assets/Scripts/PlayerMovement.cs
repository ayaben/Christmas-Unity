using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Gestion de la vitesse du player
    public float vitesse; //la vitesse du joueur qui prendra selon la situation la valeur de vitesseInitiale ou de vitesseMax
    public float vitesseInitiale; //la vitesse normale du joueur
    public float vitesseMax; //la vitesse maximale du joueur, qu'il pourra prendre lorsqu'il aura un bonus
    public float dureeAcceleration = 5f;
    float tempsAcceleration = 0;

    public PauseScript monScriptPause;

    void Start()
    {
    }

    void Update()
    {
        if (!monScriptPause.Paused) // Si le bouton pause est enfoncé, le player ne bouge pas
        {
            tempsAcceleration += Time.deltaTime; //on ajoute à chaque Update le temps qui s'est écoulé en seconde depuis la dernière frame

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-vitesse, 0, 0); //si le joueur enfonce la touche gauche de son clavier, il se déplace vers la gauche
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(vitesse, 0, 0); //si le joueur enfonce la touche droite de son clavier, il se déplace vers la droite
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -vitesse, 0); //si le joueur enfonce la touche avec la flèche vers le haut, il va vers le haut
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, vitesse, 0); //si le joueur enfonce la touche avec la flèche vers le bas, il va vers le bas
            }

            if (vitesse == vitesseMax) //si la vitesse est fixée à sa valeur maximale, donc si on a pris un sucre d'orge, on appelle la fonction UpdateVitesse pour rendre au joueur sa vitesse initiale une fois le temps du bonus terminé
            {
                UpdateVitesse();
            }

        }
    }



    public void Acceleration() //elle est appelée dans le script "GestionCollision" lors d'une collision avec le sucre d'orge
    {
        vitesse = vitesseMax; //le joueur accélère, sa vitesse devient sa vitesse max
        tempsAcceleration = 0; //on lui donne la valeur 0 au moment où le joueur commence à accélére. Il est modifié ensuite dans chaque Update
    }

    void UpdateVitesse()
    {
        if (tempsAcceleration >= dureeAcceleration) //si le temps qui s'est écoulé depuis le début de l'accélération est supérieur ou égal à la durée maximale que l'on a définie pour cette accélération
        {
            vitesse = vitesseInitiale; //on rend au joueur sa vitesse initiale
        }
    }
}