using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionCollision : MonoBehaviour
{
    int points = 0;
    public int surchargeHotteJeu = 1;
    public int surchargeHottePeluche = 1;
    public int surchargeHotteLivre = 1;
    public int surchargeHotteTotale = 3;
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
        }
    }
}