using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
	public bool doorOpen = true;
	public Collider doorcollider;
	public Renderer doorrenderer;
	public string RoterSchluessel;
	public string BlauerSchluessel;
	public string GelberSchluessel;

	// Use this for initialization
	void Start ()
	{
		doorcollider = GetComponent<Collider> ();
		doorrenderer = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (doorOpen == true) {
			Debug.Log ("Türe ist offen!");
			doorcollider.enabled = false;
			doorrenderer.enabled = false;
		} else {
			Debug.Log ("Türe ist geschlossen!");
			doorcollider.enabled = true;
			doorrenderer.enabled = true;
		}
	}
}