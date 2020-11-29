using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public int jeuCount;
	public Text jeuCountText; //le nombre de jeux dans la hotte du joueur et son affichage UI

	public int pelucheCount;
	public Text pelucheCountText; //le nombre de peluches dans la hotte du joueur et son affichage UI

	public int livreCount;
	public Text livreCountText; //le nombre de livres dans la hotte du joueur et son affichage UI

	public int objetCount = 0; //le nombre de jouets qu'a le joueur au début du jeu
	public int capaciteMax = 4; //la capacité maximale de la hotte
	public Text capaciteHotte;

	public static Inventory instance;

	private void Awake()
	{
		if(instance != null) //on s'assure qu'il n'y a qu'un seul inventaire dans le jeu
		{
			Debug.LogWarning("il y a plus d'une instance de Inventory dans la scene");
			return;
		}

		instance = this;
	}

    void Start()
    {
		capaciteHotte.text = objetCount.ToString() + "/" + capaciteMax.ToString(); //au début du jeu, on indique au joueur combien il a de jouets dans sa hotte
	}

    public void AddJeu(int count) //on ajoute les jouets récupérés lors de la collision d'une usine, la fonction est appelée dans le script "GestionCollision"
	{
		objetCount += count; //on met à jour le compte total d'objets
		jeuCount += count; //on met à jour le compte de jeux
		jeuCountText.text = jeuCount.ToString(); //on met à jour le texte qui indique au joueur combien de jeux il a dans sa hotte
		capaciteHotte.text = objetCount.ToString() + "/" + capaciteMax.ToString(); //on met à jour le texte qui indique au joueur combien de jouets il a en tout dans sa hotte
	}

	public void VideJeu(int count) //la fonction est appelée dans le script GestionCollision lors d'une collision avec une maison
    {
		objetCount = objetCount - count; //on enlève un jeu au compte total d'objets
		jeuCount = jeuCount - count; //on enlève un jeu au compte des jeux
		jeuCountText.text = jeuCount.ToString(); //on met à jour le texte qui indique au joueur combien de jeux il a dans sa hotte
		capaciteHotte.text = objetCount.ToString() + "/" + capaciteMax.ToString(); //on  met à jour le texte qui indique au joueur combien de jouets il a en tout dans as hotte
	}

	public void AddPeluche(int count) //la fonction AddPeluche fonctionne comme AddJeu
	{
		objetCount += count;
		pelucheCount += count;
		pelucheCountText.text = pelucheCount.ToString();
		capaciteHotte.text = objetCount.ToString() + "/" + capaciteMax.ToString();
	}

	public void VidePeluche(int count) //la fonction VidePeluche fonctionne comme VideJeu
	{
		objetCount = objetCount - count;
		pelucheCount = pelucheCount - count;
		pelucheCountText.text = pelucheCount.ToString();
		capaciteHotte.text = objetCount.ToString() + "/" + capaciteMax.ToString();
	}

	public void AddLivre(int count) //la fonction AddLivre fonctionne comme AddJeu
	{
		objetCount += count;
		livreCount += count;
		livreCountText.text = livreCount.ToString();
		capaciteHotte.text = objetCount.ToString() + "/" + capaciteMax.ToString();
	}

	public void VideLivre(int count) //la fonction VideLivre fonctionne comme VideJeu
	{
		objetCount = objetCount - count;
		livreCount = livreCount - count;
		livreCountText.text = livreCount.ToString();
		capaciteHotte.text = objetCount.ToString() + "/" + capaciteMax.ToString();
	}

	public void VideHotte() //la fonction est appelée dans le script "GestionCollision" pour une collision avec la poubelle
	{
		objetCount = 0; //on laisse tous ses objets, donc la valeur du nombre totale d'objet est 0
		jeuCount = 0;
		jeuCountText.text = jeuCount.ToString(); //on met à jour le nombre de jeux dans la hotte et son affichage
		pelucheCount = 0;
		pelucheCountText.text = pelucheCount.ToString(); //on met à jour le nombre de peluches dans la hotte et son affichage
		livreCount = 0;
		livreCountText.text = livreCount.ToString(); //on met à jour le nombre de livres dans la hotte et son affichage
		capaciteHotte.text = objetCount.ToString() + "/" + capaciteMax.ToString(); //on met à jour l'affichage du nombre total de jouets dans la hotte 
	}

}
