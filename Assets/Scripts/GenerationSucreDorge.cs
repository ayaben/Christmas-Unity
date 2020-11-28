using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class GenerationSucreDorge : MonoBehaviour
{
    public Transform ObjetPrefab; //On applique le script sur un empty "GenerationSo" et on glisse dans l'inspecteur le prefab de l'objet à instancier, un sucre d'orge ici. Il peut y avoir plusieurs zones de création de sucre d'orge, on prévoit donc un script générique
    public float intervalleCreation = 5f; // correspond au délai entre chaque génération de sucre d'orge. On lui attribue une valeur par défaut par précaution, mais cette valeur sera définie de manière aléatoire au moment du début du jeu.
    float tempsCreation = 0; //correspond au moment de l'update

    void Update()
    {
        intervalleCreation = Random.Range(10f, 31f); //intervalle de création aléatoire, compris entre x et x secondes
        tempsCreation += Time.deltaTime;

        if (tempsCreation >= intervalleCreation) //Si le temps de l'update (à 0 au début du jeu, puis redéfini à 0 à chaque fois que l'on crée des sucres d'orge) est supérieur ou égal à l'intervalle que l'on a défini comme délai entre chaque création, on génère de nouveaux sucres d'orge.
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
        objetARamasser.GenerationSO = this; // lie l'objet à l'objet qui le crée : l'objet de l'objet à ramasser = l'objet sur lequel il y a ce script
        Vector3 positionGenerationSO = this.gameObject.transform.position;

        float posX = Random.Range(-12, 19);  
        float posY = Random.Range(-13, 17); 
        nouveauObjet.position = positionGenerationSO + new Vector3(posX, posY, -0.01f); //on définit une position aléatoire par rapport à la position de l'objet GenerationSO. Cela permet de générer des sucres d'orge avec une position élatoire si l'on a plusieurs zones de création de sucres d'orge.
    }


}