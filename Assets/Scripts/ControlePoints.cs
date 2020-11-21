using UnityEngine;
using UnityEngine.UI;

public class ControlePoints : MonoBehaviour
{
	public int comptedepoints = 0;
	public Text pointsText;
	public static ControlePoints instance;

	private void Awake()
	{
		if (instance != null)
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
}
