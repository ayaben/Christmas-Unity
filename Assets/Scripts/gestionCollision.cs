using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    public AudioSource Gift, Slurp, Trash, Pop, Surcharge;
    public int surchargeHotteTotale = 4; //le nombre de jouets que peut contenir la hotte au maximum tous types de jouets confondus


    void OnTriggerEnter2D(Collider2D collision) //s'il y a une collision avec un autre objet, on appelle une fonction qui définit le type d'interaction qui va intervenir
    {
        ObjetARamasser objetARamasser = collision.transform.gameObject.GetComponent<ObjetARamasser>(); //Le script ObjetARamasser nous permet de définir le type d'interaction. On le récupère sur chaque objet avec lequel on entre en collision
        if (objetARamasser)
        {
            handlecollisionobjet(objetARamasser);
        }
    }

    void handlecollisionobjet(ObjetARamasser objetARamasser) {
        if (objetARamasser.Type == TypeObjet.PELUCHE && Inventory.instance.objetCount < surchargeHotteTotale) //Si l'objet rencontré est une peluche, et que le nombre total de jouets déjà contenus dans la hotte est inférieur à sa capacité maximale, on peut ramasser l'objet
        {
            print("Chouette, j'ai touché une peluche");
            Destroy(objetARamasser.gameObject); //on détruit l'objet, pour qu'il disparaisse. On le met alors dans notre hotte
            Inventory.instance.AddPeluche(1); //on ajoute une peluche à notre inventaire
            objetARamasser.Usine.nombreObjetUsine--; //on a récupéré un objet, on supprime donc 1 objet dans l'usine correspondante, pour que celle-ci puisse continuer à générer des objets et qu'elle ne considère pas que cet objet est toujours dans l'usine
            Gift.Play(); //on déclenche un bruitage qui indique que l'on a récupérer un objet
        }

        //Les actions à effectuer sur les objets de type "livre" et "jeu" sont les mêmes que pour les peluches
        if (objetARamasser.Type == TypeObjet.LIVRE && Inventory.instance.objetCount < surchargeHotteTotale)
        {
            print("Chouette, j'ai touché un livre");
            Destroy(objetARamasser.gameObject);
            Inventory.instance.AddLivre(1);
            objetARamasser.Usine.nombreObjetUsine--;
            Gift.Play();
        }

        if (objetARamasser.Type == TypeObjet.JEU && Inventory.instance.objetCount < surchargeHotteTotale)
        {
            print("Chouette, j'ai touché un jeu");
            Destroy(objetARamasser.gameObject);
            Inventory.instance.AddJeu(1);
            objetARamasser.Usine.nombreObjetUsine--;
            Gift.Play();
        }

        if(objetARamasser.Type == TypeObjet.SUCREDORGE) 
        {
            print("Youpi, un sucre d'orge");
            Destroy(objetARamasser.gameObject); //on ramasse le sucre d'orge, donc on le détruit
            PlayerMovement playermovement = this.GetComponent<PlayerMovement>(); //On fait le lien avec le script qui gère le mouvement du player
            playermovement.Acceleration(); //dans le script qui gère le mouvement du player, on fait appel à la fonction "accélération", le bonus qui est déclenché lorsqu'on rencontre un sucre d'orge
            Slurp.Play(); //on déclenche un bruitage qui indique au joueur qu'il a récupéré un sucre d'orge, et qu'il a un bonus
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Poubelle")) //si l'objet a un tag "poubelle"
        {
            Debug.Log("Poubelle");
            Inventory.instance.VideHotte(); //on vient vider sa hotte, donc on fait appel à la fonction correspondante dans le script d'inventaire pour qu'il  mette à jour le nombre d'objet dans la hotte
            ControlePoints.instance.SupprimePoint(1); //on enlève un point au joueur qui vient vider sa hotte dans la poubelle, car il gaspille. On fait appel au script de contrôle des points
            Trash.Play(); //On déclenche le bruitage correspondant à  la poubelle
        }

        if (collision.gameObject.CompareTag("Maison")) //si l'objet a un tag "maison", donc, si l'objet est une maison
        {
            Debug.Log("Maison");

            ListesMaisons listemaison = collision.transform.GetComponent<ListesMaisons>(); //on se réfère aux informations contenues dans le script "ListesMaisons" placé sur chaque maison
            if (listemaison.VoeuJeu > 0 && Inventory.instance.jeuCount > 0) //S'il y a au moins un jeu de société à livrer sur la maison, et si on en a au moins 1 dans sa hotte
            {
                listemaison.VoeuJeu = listemaison.VoeuJeu - 1; //il y a un jeu de moins à livrer
                listemaison.Updatetext(); //on met à jour la liste de la maison correspondante
                Inventory.instance.VideJeu(1); //on fait appel à la fonction "VideJeu" dans l'inventaire pour livrer 1 jeu
                ControlePoints.instance.AjoutPoint(1); //on ajoute un point au joueur car il a réussi à livrer un jouet
                ControlePoints.instance.ReduirePointAtteindre(1); //il y a un jouet de moins à livrer sur le total défini en début de jeu.
                Pop.Play(); //Le bruitage indique au joueur qu'il a livré un jouet
            }

            //les actions à effectuer sur les listes des maisons sont les mêmes pour les objets de type "peluche" et "livre" que pour les objets de type "jeu"
            if (listemaison.VoeuPeluche > 0 && Inventory.instance.pelucheCount > 0)
            {
                listemaison.VoeuPeluche = listemaison.VoeuPeluche - 1;
                listemaison.Updatetext();
                Inventory.instance.VidePeluche(1);
                ControlePoints.instance.AjoutPoint(1);
                ControlePoints.instance.ReduirePointAtteindre(1);
                Pop.Play();
            }

            if (listemaison.VoeuLivre > 0 && Inventory.instance.livreCount > 0)
            {
                listemaison.VoeuLivre = listemaison.VoeuLivre - 1;
                listemaison.Updatetext();
                Inventory.instance.VideLivre(1);
                ControlePoints.instance.AjoutPoint(1);
                ControlePoints.instance.ReduirePointAtteindre(1);
                Pop.Play();
            }
        }
    }
}