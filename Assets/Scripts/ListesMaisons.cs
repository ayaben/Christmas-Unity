using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListesMaisons : MonoBehaviour
{
    public GameObject[] mapetiteListe;
    string afficheListe = "";


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        afficheListe = "";
        for (int i = 0; i < transform.childCount; i++)
        {
            print(i);
            afficheListe = afficheListe + "- " + transform.GetChild(i).name;
        }
        print(afficheListe);
    }
} 