using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class GenerationCreation : MonoBehaviour
{
    public Transform ObjetPrefab;
    public float intervalleCreation = 1f;
    public int nombreObjetMax = 4;
    public int nombreObjetMaxCreable = 3;
    float tempsCreation = 0;
    [HideInInspector]
    public int nombreObjetUsine = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tempsCreation += Time.deltaTime;

        if (tempsCreation >= intervalleCreation){
            // nombreObjet = nombre d'objets à créer
            int nombreObjetMaxCreableNow = Math.Min(nombreObjetMaxCreable, nombreObjetMax - nombreObjetUsine);
            int nombreObjet = Random.Range(0, nombreObjetMaxCreableNow+1);
            tempsCreation = 0;
            nombreObjetUsine += nombreObjet;

            for (int i=0; i < nombreObjet; i++){
                creationObjet();
            }
        }

    }

    void creationObjet(){
        print("je produis");
        Transform nouveauObjet = Instantiate(ObjetPrefab);
        ObjetARamasser objetARamasser = nouveauObjet.gameObject.GetComponent<ObjetARamasser>();
        objetARamasser.Usine = this; // lie l'objet à l'usine qui le crée : l'usine de objet à ramasser = l'usine sur laquelle il y a ce script
        Vector3 positionUsine = this.gameObject.transform.position;

        float posX = Random.Range(-2, 2); // variation par rapport à la position de l'usine
        float posY = Random.Range(-2, 2); // variation par rapport à la position de l'usine
        nouveauObjet.position = positionUsine + new Vector3(posX, posY, -0.01f); //détermine la position de l'objet créé par rapport à la position de l'usine 
    }


}