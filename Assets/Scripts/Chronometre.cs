using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chronometre : MonoBehaviour {

	public Text label;
	int leTemps = 120;
	int minutes ;
	int secondes;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		leTemps = 120 - (int)Time.realtimeSinceStartup;
		minutes = leTemps / 60;
		secondes = leTemps % 60;
		if (secondes > 9) {
			label.text = minutes + ":" + secondes;
		} else {
			label.text = minutes + ":0" + secondes;
		}
	}
}
