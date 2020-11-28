using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class GenerationCreation : MonoBehaviour
{
    public Transform ObjetPrefab; //Pour chaque usine, on définit un "prefab" d'objet à instancier, soit jeu, soit peluche, soit livre
    public float intervalleCreation = 1f;
    public int nombreObjetMax = 4; //le nombre 
    public int nombreObjetMaxCreable = 3;
    float tempsCreation = 0; //correspond au moment de l'ubdate
    [HideInInspector] //on cache le nombre d'objets dans l'usine dans l'inspecteur pour ne pas risquer de modifier cette variable
    public int nombreObjetUsine = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        tempsCreation += Time.deltaTime;

        if (tempsCreation >= intervalleCreation){
            int nombreObjetMaxCreableNow = Math.Min(nombreObjetMaxCreable, nombreObjetMax - nombreObjetUsine); //le nombre d'objets qu'on peut créer à ce moment : il correspond au nombre d'objets que peut contenir l'objet au maximum (4) auquel on soustrait le nombre d'objets qu'il y a déjà dans l'usine. La fonction Math.min impose que l'on ne crée pas + de 3 objets à la fois, car elle retournera le nombre le plus petit, entre 3 et la soustraction déjà mentionnée (nombre d'objets max contenu par une usine - le nombre d'objets déjà dans l'usine)
            int nombreObjet = Random.Range(0, nombreObjetMaxCreableNow+1); // nombreObjet = nombre d'objets à créer. Il est redéfini aléatoirement à chaque update, pour que l'apparition des jouets dans les usines ne soit pas régulière
            tempsCreation = 0; //il s'est passé 0 secondes depuis la dernière création d'objet, qui correspond à maintenant
            nombreObjetUsine += nombreObjet; //On ajoute le nombre d'objets intanciés au compte d'objets dans l'usine, pour permettre de limiter la génération d'objets

            for (int i=0; i < nombreObjet; i++){
                creationObjet(); //tant que le nombre d'objet est inférieur au nombre d'objet qu'on peut créer, on instancie des objets
            }
        }

    }

    void creationObjet(){
        print("je produis");
        Transform nouveauObjet = Instantiate(ObjetPrefab); //on instancie le préfab que l'on a glissé dans l'inspecteur pour chaque type d'usine
        ObjetARamasser objetARamasser = nouveauObjet.gameObject.GetComponent<ObjetARamasser>(); //Le script "ObjetARamasser" est glissé sur chaque prefab. Avec cette méthode, on récupère le script placé sur chaque objet, qui précise une variable usine dont on va avoir besoin ici pour déterminer la position du nouvel objet instancié.
        objetARamasser.Usine = this; // lie l'objet à l'usine qui le crée : l'usine de objet à ramasser = l'usine sur laquelle il y a ce script
        Vector3 positionUsine = this.gameObject.transform.position; //on définit la position de l'usine par rapport à l'objet "usine" particulier sur lequel est posé le script

        float posX = Random.Range(-2, 2); // variation par rapport à la position de l'usine
        float posY = Random.Range(-2, 2); // variation par rapport à la position de l'usine
        nouveauObjet.position = positionUsine + new Vector3(posX, posY, -0.01f); //détermine la position de l'objet créé par rapport à la position de l'usine 
    }


}