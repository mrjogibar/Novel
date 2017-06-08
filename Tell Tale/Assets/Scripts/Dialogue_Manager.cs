using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Manager : MonoBehaviour {

	//Singleton property
	public static Dialogue_Manager Instance { get; private set; }

	void Awake()
	{
		if (Instance != null && Instance != this) 
		{
			Destroy(gameObject);
		}

		Instance = this;

		gameObject.AddComponent<AudioSource> ();
	}

	public void BeginDialogue (AudioClip passedClip)
	{
        //set and play the audio-clip
        audio = passedClip;
        GetComponent<AudioSource>().PlayOneShot ();
	}
}
