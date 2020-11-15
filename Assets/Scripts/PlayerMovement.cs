using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float vitesse;

	void Start ()
	{

	}

    void Update()
    {
        transform.Translate(0,0, vitesse);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
        	transform.Translate(-vitesse,0,0);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
        	transform.Translate(vitesse,0,0);
        }

        transform.Translate(0,0, vitesse);
        if(Input.GetKey(KeyCode.DownArrow))
        {
        	transform.Translate(0, -vitesse,0);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
        	transform.Translate(0, vitesse,0);
        }
   }
}