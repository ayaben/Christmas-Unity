using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	
	float time; //temps écoulé depuis le début
	public Text TimerText;
	public float TimerInterval=5f;
	float tick;


    void Awake() //void Awake s'effectue avant même le Start
    {
        time = (int)Time.time;
        tick = TimerInterval;
    }


    void Update()
    {
        TimerText.text = string.Format("{0:0}:{1:00}",Mathf.Floor(time/60),time%60); //pour afficher le timer en format minutes : secondes

        time = (int)Time.time;

        if(time==tick)
        {
        	tick = time + TimerInterval;
        	//Executer le code du timer
        	TimerExecute ();
        }
    }

    void TimerExecute()
    {
    	Debug.Log("Timer");
    }
}
