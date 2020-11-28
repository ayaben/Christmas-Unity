using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    public AudioSource Gift, Slurp, Trash, Pop, Surcharge;
    //public int points = 0;
    public int surchargeHotteJeu = 1;
    public int surchargeHottePeluche = 1;
    public int surchargeHotteLivre = 1;
    public int surchargeHotteTotale = 3;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ObjetARamasser objetARamasser = collision.transform.gameObject.GetComponent<ObjetARamasser>();
        if (objetARamasser)
        {
            handlecollisionobjet(objetARamasser);
        }
    }

    void handlecollisionobjet(ObjetARamasser objetARamasser) {
        if (objetARamasser.Type == TypeObjet.PELUCHE && Inventory.instance.objetCount < surchargeHotteTotale)
        {
            print("Chouette, j'ai touché une peluche");
            Destroy(objetARamasser.gameObject);
            Inventory.instance.AddPeluche(1);
            objetARamasser.Usine.nombreObjetUsine--;
            Gift.Play();
        }

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
            Destroy(objetARamasser.gameObject);
            PlayerMovement playermovement = this.GetComponent<PlayerMovement>();
            playermovement.Acceleration();
            Slurp.Play();
        }

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Poubelle"))
        {
            Debug.Log("Poubelle");
            Inventory.instance.VideHotte();
            ControlePoints.instance.SupprimePoint(1);
            Trash.Play();
        }

        if (collision.gameObject.CompareTag("Maison"))
        {
            Debug.Log("Maison");

            ListesMaisons listemaison = collision.transform.GetComponent<ListesMaisons>();
            if (listemaison.VoeuJeu > 0 && Inventory.instance.jeuCount > 0)
            {
                listemaison.VoeuJeu = listemaison.VoeuJeu - 1;
                listemaison.Updatetext();
                Inventory.instance.VideJeu(1);
                ControlePoints.instance.AjoutPoint(1);
                ControlePoints.instance.ReduirePointAtteindre(1);
                Pop.Play();
            }

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