using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using UnityEngine.UI;

public class ListesMaisons : MonoBehaviour
{
    public Text ListedeVoeux;
    public string[] mapetiteListe;
    //string afficheListe = "";
    //public transform = Livre;


    void Start()
    {
        int VoeuLivre = Random.Range(5, 10);
        int VoeuJeu = Random.Range(5, 10);
        int VoeuPeluche = Random.Range(5, 10);
        mapetiteListe[0] = "- " + VoeuLivre.ToString() + " livres\n";
        mapetiteListe[1] = "- " + VoeuJeu.ToString() + " jeux" + "\n";
        mapetiteListe[2] = "- " + VoeuPeluche.ToString() + " peluches";

        print(mapetiteListe);
        ListedeVoeux.text = mapetiteListe[0] + mapetiteListe[1] + mapetiteListe[2];

    }

    // Update is called once per frame
    void Update()
    {
    }
}