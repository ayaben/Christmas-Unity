using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    //public int points = 0;
    public int surchargeHotteJeu = 1;
    public int surchargeHottePeluche = 1;
    public int surchargeHotteLivre = 1;
    public int surchargeHotteTotale = 3;
    //public fichier bruitage à glisser déposer dans l'éditeur
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        ObjetARamasser objetARamasser = collision.transform.gameObject.GetComponent<ObjetARamasser>();
        if (objetARamasser)
        {
            handlecollisionobjet(objetARamasser);
            //GetComponent<AudioSource>().Play();
        }
    }

    void handlecollisionobjet(ObjetARamasser objetARamasser) { 
        if (objetARamasser.Type==TypeObjet.PELUCHE && Inventory.instance.objetCount<surchargeHotteTotale)
        {
            print("Chouette, j'ai touché une peluche");
            Destroy(objetARamasser.gameObject);
            Inventory.instance.AddPeluche(1);
            objetARamasser.Usine.nombreObjetUsine--;
        }

        if (objetARamasser.Type == TypeObjet.LIVRE && Inventory.instance.objetCount < surchargeHotteTotale)
        {
            print("Chouette, j'ai touché un livre");
            Destroy(objetARamasser.gameObject);
            Inventory.instance.AddLivre(1);
            objetARamasser.Usine.nombreObjetUsine--;
        }


        if (objetARamasser.Type == TypeObjet.JEU && Inventory.instance.objetCount < surchargeHotteTotale)
        {
            print("Chouette, j'ai touché un jeu");
            Destroy(objetARamasser.gameObject);
            Inventory.instance.AddJeu(1);
            objetARamasser.Usine.nombreObjetUsine--;
        }


    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Poubelle"))
        {
            Debug.Log("Poubelle");
            Inventory.instance.VideHotte();
            //bruit poubelle
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
            }

            if (listemaison.VoeuPeluche > 0 && Inventory.instance.pelucheCount > 0)
            {
                listemaison.VoeuPeluche = listemaison.VoeuPeluche - 1;
                listemaison.Updatetext();
                Inventory.instance.VidePeluche(1);
            }

            if (listemaison.VoeuLivre > 0 && Inventory.instance.livreCount > 0)
            {
                listemaison.VoeuLivre = listemaison.VoeuLivre - 1;
                listemaison.Updatetext();
                Inventory.instance.VideLivre(1);
            }
        }
    }
}