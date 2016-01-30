using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Chronometre : MonoBehaviour {

	public Text label;
	public static float tempsRestant;
	public float leTemps;
	int minutes ;
	int secondes;

	public List<GameObject> objetsActivables = new List<GameObject>();
	public List<GameObject> objetsDesactivables = new List<GameObject>();

	// Use this for initialization
	void Start () {
		tempsRestant = leTemps;
	}
	
	// Update is called once per frame
	void Update () {
		minutes = (int) tempsRestant / 60;
		secondes = (int) tempsRestant % 60;
		if (secondes > 9) {
			label.text = minutes + ":" + secondes;
		} else {
			label.text = minutes + ":0" + secondes;
		}
		if (tempsRestant < .0f) {
			foreach (GameObject i in objetsActivables) {
				i.SetActive (true);
			}
			foreach (GameObject i in objetsDesactivables) {
				i.SetActive (false);
			}
			tempsRestant = 0;
		} else if(tempsRestant > 0) {
			tempsRestant -= Time.deltaTime;
		}
	}
}
