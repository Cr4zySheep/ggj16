using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Chronometre : MonoBehaviour {

	public Text label;
	public int leTemps;
	int minutes ;
	int secondes;
	int startingTime;

	public List<GameObject> objetsActivables = new List<GameObject>();
	public List<GameObject> objetsDesactivables = new List<GameObject>();

	// Use this for initialization
	void Start () {
		startingTime = leTemps;
	}
	
	// Update is called once per frame
	void Update () {
		leTemps = startingTime - (int)Time.realtimeSinceStartup;
		minutes = leTemps / 60;
		secondes = leTemps % 60;
		if (secondes > 9) {
			label.text = minutes + ":" + secondes;
		} else {
			label.text = minutes + ":0" + secondes;
		}
		if ((int)leTemps<1) {
			//GameObject.Find("GameOver").SetActive (true);
			//GameObject.Find ("Player").Mouvement.SetActive(false);
			foreach (GameObject i in objetsActivables) {
				i.SetActive(true);
			}
			foreach (GameObject i in objetsDesactivables){
				i.SetActive(false);
			}
		}
	}
}
