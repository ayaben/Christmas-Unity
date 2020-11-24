﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using UnityEngine.UI;

public class ListesMaisons : MonoBehaviour
{
    public Text ListedeVoeux;
    public string[] mapetiteListe;
    public int VoeuLivre;
    public int VoeuJeu;
    public int VoeuPeluche;
    //string afficheListe = "";
    //public transform = Livre;


   public void Start()
    {
        VoeuLivre = Random.Range(1, 2);
        VoeuJeu = Random.Range(1, 2);
        VoeuPeluche = Random.Range(1, 2);
        Updatetext();
        ControlePoints.instance.AjoutPointaAtteindre(VoeuJeu+VoeuLivre+VoeuPeluche);



    }


    public void Updatetext()
    {
        mapetiteListe[0] = "- " + VoeuLivre.ToString() + " livres\n";
        mapetiteListe[1] = "- " + VoeuJeu.ToString() + " jeux" + "\n";
        mapetiteListe[2] = "- " + VoeuPeluche.ToString() + " peluches";

        ListedeVoeux.text = mapetiteListe[0] + mapetiteListe[1] + mapetiteListe[2];

        if (VoeuLivre<=1)
        {
            mapetiteListe[0]= "- " + VoeuLivre.ToString() + " livre\n";

            ListedeVoeux.text = mapetiteListe[0] + mapetiteListe[1] + mapetiteListe[2];
        }

        if (VoeuJeu<=1)
        {
            mapetiteListe[1] = "- " + VoeuJeu.ToString() + " jeu" + "\n";

            ListedeVoeux.text = mapetiteListe[0] + mapetiteListe[1] + mapetiteListe[2];
        }

        if (VoeuPeluche<=1)
        {
            mapetiteListe[2] = "- " + VoeuPeluche.ToString() + " peluche";

            ListedeVoeux.text = mapetiteListe[0] + mapetiteListe[1] + mapetiteListe[2];
        }

        if (VoeuLivre==0 && VoeuJeu==0 && VoeuPeluche ==0)
        {
            ListedeVoeux.text = "Mission accomplie ici !";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}