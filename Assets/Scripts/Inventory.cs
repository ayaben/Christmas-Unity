using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public int coinsCount;
	public Text coinsCountText;

	public int jeuCount;
	public Text jeuCountText;

	public int pelucheCount;
	public Text pelucheCountText;

	public int livreCount;
	public Text livreCountText;

	public int objetCount;

	public static Inventory instance;

	private void Awake()
	{
		if(instance != null)
		{
			Debug.LogWarning("il y a plus d'une instance de Inventory dans la scene");
			return;
		}

		instance = this;
	}

	public void AddJeu(int count)
	{
		objetCount += count;
		jeuCount += count;
		jeuCountText.text = jeuCount.ToString();
	}

	public void VideJeu(int count)
    {
		objetCount = objetCount - count;
		jeuCount = jeuCount - count;
		jeuCountText.text = jeuCount.ToString();
    }

	public void AddPeluche(int count)
	{
		objetCount += count;
		pelucheCount += count;
		pelucheCountText.text = pelucheCount.ToString();
	}

	public void VidePeluche(int count)
	{
		objetCount = objetCount - count;
		pelucheCount = pelucheCount - count;
		pelucheCountText.text = pelucheCount.ToString();
	}

	public void AddLivre(int count)
	{
		objetCount += count;
		livreCount += count;
		livreCountText.text = livreCount.ToString();
	}

	public void VideLivre(int count)
	{
		objetCount = objetCount - count;
		livreCount = livreCount - count;
		livreCountText.text = livreCount.ToString();
	}

	public void VideHotte()
	{
		objetCount = 0;
		jeuCount = 0;
		jeuCountText.text = jeuCount.ToString();
		pelucheCount = 0;
		pelucheCountText.text = pelucheCount.ToString();
		livreCount = 0;
		livreCountText.text = livreCount.ToString();
	}

}
