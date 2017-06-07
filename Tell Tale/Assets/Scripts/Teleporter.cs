using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{


	public Transform Ziel;
	public Transform Player;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	 
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {

			other.transform.position = Ziel.transform.position;
		}
	}



	
}

