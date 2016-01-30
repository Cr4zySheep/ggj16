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

	public Text ScoreVert;
	public Text ScoreJaune;
	public Text ScoreHaut;
	public Text ScoreBas;

	public List<GameObject> objetsActivables = new List<GameObject>();
	public List<GameObject> objetsDesactivables = new List<GameObject>();

	public Possession player1;
	public Possession player2;
	List<Possession> joueurs = new List<Possession>();
	public int numero;
	float tempsPossession;

	// Use this for initialization
	void Start () {
		tempsRestant = leTemps;
		joueurs.Add (player1);
		joueurs.Add (player2);
		numero = Random.Range (1, 3);
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
			// Affichage des scores réels et classement
			if (int.Parse (ScoreJaune.text) > int.Parse (ScoreVert.text)) {
				ScoreHaut.text = "Player 2 : " + int.Parse (ScoreJaune.text);
				ScoreBas.text = "Player 1 : " + int.Parse (ScoreVert.text);
			} else {
				ScoreHaut.text = "Player 1 : " + int.Parse (ScoreVert.text);
				ScoreBas.text = "Player 2 : " + int.Parse (ScoreJaune.text);
			}
			// AJOUTER LE CAS DE l'EGALITE

			foreach (GameObject i in objetsDesactivables) {
				i.SetActive (false);
			}
			tempsRestant = 0;
		} else if(tempsRestant > 0) {
			tempsRestant -= Time.deltaTime;
		}

		//Gerer la possession

		tempsPossession += Time.deltaTime;
		if ((int) tempsPossession == 30) {
			joueurs [numero % 2].possessed = true;
			//Debug.Log (joueurs [numero % 2].possessed);
		}
		if ((int) tempsPossession == 45) {
			joueurs [numero%2].possessed = false;
			numero = numero + 1;
			tempsPossession = 0;
			//Debug.Log (joueurs [numero % 2].possessed);
		}

	}


}
