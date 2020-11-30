using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlePoints : MonoBehaviour
{
	public int comptedepoints = 0; //au début du jeu, le joueur n'a encore marqué aucun point. La valeur par défaut est donc nulle
	public Text pointsText; //L'objet UI qui permettra l'affichage des points à l'écran
	public static ControlePoints instance;
	public int pointaAtteindre ; //le nombre de points à atteindre pour gagner, qui est défini par la somme du nombre de tous les jouets à livrer sur l'ensemble des maisons




	private void Awake()
	{
		if (instance != null) //on s'assure avec cette condition qu'il n'y bien qu'un seul script de contrôle de points dans la scène. C'est important car le compte des points est ce qui détermine la réussite ou l'échec du joueur dans le jeu.
		{
			Debug.LogWarning("il y a plus d'une instance de ControlePoints dans la scene");
			return;
		}

		instance = this;
	}

    public void Start()
    {
		pointsText.text = "Points : " + comptedepoints.ToString(); 
    }

    public void AjoutPoint(int count)
    {
		comptedepoints = comptedepoints + count;
		pointsText.text = "Points : " + comptedepoints.ToString();
    }

	public void SupprimePoint(int count)
    {
		comptedepoints = comptedepoints - count;
		pointsText.text = "Points : " + comptedepoints.ToString();
	}

	public void AjoutPointaAtteindre(int count) //Lors du début du jeu, chaque maison ajoute la somme des objets qu'il y a à livrer sur son emplacement à ce compte total de points.
	{
		pointaAtteindre += count;

	}

	public void ReduirePointAtteindre( int count) //À chaque fois que le joueur livre un objet, on enlève un point à ce compte total
	{
		pointaAtteindre -= count;

	}

	void Update() 
	{
		if(pointaAtteindre ==0){
			pointsText.text = "Points : " + comptedepoints.ToString();
			PlayerPrefs.SetString("Score", "Points : " + comptedepoints.ToString());
		    SceneManager.LoadScene("Win"); //Si tous les objets ont été livrés, le compte arrive à zéro. Le joueur a alors gagné le jeu
		}
	}
}
