using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetARamasser : MonoBehaviour 
{
    public TypeObjet Type; //on attribue un type à chaque objet, c'est ce type qui permettra de définir l'interaction entre le joueur lors de sa collision avec des maisons. C'est aussi avec le type que l'on définit dans chaque usine quel type de jouet est produit.

    [HideInInspector] //les valeurs suivantes sont cachées dans l'inspecteur car on n'a pas besoin de les attribuer. Elles permettent de faire le lien dans les scripts de génération d'objets avec la position de l'objet (usine ou GenerationSO) sur lequel on instancie l'objet. On  les désignera par "this" pour renvoyer à l'instance particulière de l'usine sur laquelle est placée le script.
    public GenerationCreation Usine;
    public GenerationSucreDorge GenerationSO;
}

public enum TypeObjet
{
    LIVRE, JEU, PELUCHE, SUCREDORGE
}
