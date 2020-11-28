using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System;
using UnityEngine.UI;

public class ListesMaisons : MonoBehaviour //Le script est public pour qu'on puisse le lier avec d'autres scripts, notamment "Gestion Collision". Il est appliqué sur chaque objet de type "maison"
{
    public Text ListedeVoeux; //Dans l'inspecteur de chaque maison où l'on a placé ce script, on glisse un objet UI de type texte. C'est cet objet qui permettra d'afficher pour chaque maison une liste différente
    public string[] mapetiteListe; 
    public int VoeuLivre;
    public int VoeuJeu;
    public int VoeuPeluche;
    public AudioSource MaisonLivreeSound;


   public void Start()
    {
        VoeuLivre = Random.Range(1, 4); //Pour chaque maison, la lite affiche un nombre de livres à livrer. Le nombre est défini au début (void Start) du jeu de façon aléatoire, entre 1 et 3 (et non 1 et 4, parce que le Random.Range exclut la valeur max indiquée. Donc Random.Range(1,4) = entre 1 et 3
        VoeuJeu = Random.Range(1, 4);
        VoeuPeluche = Random.Range(1, 4);
        Updatetext();
        ControlePoints.instance.AjoutPointaAtteindre(VoeuJeu+VoeuLivre+VoeuPeluche); //On définit dans le script du compte des points le nombre de points que le joueur devra atteindre pour réussir le jeu. Ce compte est défini par la somme du nombre de jouets à livrer sur chaque maison. Pour chaque maison, au moment du début du jeu, on ajoute le nombre de points correspondant, c'est le total de tous les jouets sur les listes de toutes les maisons qui définit le nombre de points à atteindre.

    }


    public void Updatetext() //la fonction Updatetext est publique pour pouvoir être appelée dans le script "GestionCollision".
    {
        mapetiteListe[0] = "- " + VoeuLivre.ToString() + " livres\n";
        mapetiteListe[1] = "- " + VoeuJeu.ToString() + " jeux" + "\n";
        mapetiteListe[2] = "- " + VoeuPeluche.ToString() + " peluches";

        //pour chaque maison, on traduit l'integer en texte pour qu'il puisse s'intégrer dans la liste de type "string". On affiche ensuite les éléments de cette liste dans le texte UI ListeMaison qui correspond à chaque maison.
        ListedeVoeux.text = mapetiteListe[0] + mapetiteListe[1] + mapetiteListe[2];

        //Les conditions suivantes permettent d'accorder "livre", "jeu" et "peluche" au singulier, s'il reste 1 seul (ou aucun) de ce type de jouet à livrer.
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

        if (VoeuLivre==0 && VoeuJeu==0 && VoeuPeluche ==0) //Si tous les livres, jeux et peluche ont été livrés sur cette maison, on veut remplacer la liste  par un message qui indique au joueur qu'il n'a plus rien à livrer à cet emplacement.
        {

            ListedeVoeux.text = "Mission accomplie ici !";
            MaisonLivreeSound.Play();
        }
    }
}