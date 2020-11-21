using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class GenerationSucreDorge : MonoBehaviour
{
    public Transform ObjetPrefab;
    public float intervalleCreation = 60f;
    float tempsCreation = 0;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        intervalleCreation = Random.Range(2f, 4f); //intervalle de création aléatoire, régler entre 30 et 60f une fois la phase d'essais terminée
        tempsCreation += Time.deltaTime;

        if (tempsCreation >= intervalleCreation)
        {
            creationSucreDorge();
            tempsCreation = 0;
        }

    }

    void creationSucreDorge()
    {
        print("je sucre dorge");
        Transform nouveauObjet = Instantiate(ObjetPrefab);
        ObjetARamasser objetARamasser = nouveauObjet.gameObject.GetComponent<ObjetARamasser>();
        objetARamasser.GenerationSO = this; // lie l'objet à l'usine qui le crée : l'usine de objet à ramasser = l'usine sur laquelle il y a ce script
        Vector3 positionGenerationSO = this.gameObject.transform.position;

        float posX = Random.Range(-2, 2); // variation par rapport à la position de l'usine
        float posY = Random.Range(-2, 2); // variation par rapport à la position de l'usine
        nouveauObjet.position = positionGenerationSO + new Vector3(posX, posY, -0.01f);
    }


}