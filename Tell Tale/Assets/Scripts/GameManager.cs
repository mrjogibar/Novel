using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int punkte;
	public Text anzeige;
	public RectTransform leben;
	public int health;
	public int maxHealth;

	public static GameManager instance;
	void Awake() {
	if ( instance == null ) 
	{
		instance = this;
	} 
	else if ( instance != this ) 
	{
		Destroy(gameObject);
	}

	DontDestroyOnLoad(gameObject);
	}

	public void OnGUI() {
		anzeige.text = "Punkte: " + punkte;
		leben.localScale = new Vector3 ((float) health / maxHealth , 1,1);
	}

	


}
