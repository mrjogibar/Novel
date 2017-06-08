using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour {

	public AudioClip dialogueClip;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Dialogue_Manager.Instance.BeginDialogue(dialogueClip);
		}
	}
}