using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficherVictoire : MonoBehaviour
{
    public Text ScoreFinal;
    public Text TempsFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreFinal.text = PlayerPrefs.GetString("ScoreFinal"); // Affiche les points récoltés pendant le jeu
        TempsFinal.text = PlayerPrefs.GetString("TempsFinal"); // Affiche le temps passé à jouer
    }
}
