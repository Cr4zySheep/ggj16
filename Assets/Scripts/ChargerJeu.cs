using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChargerJeu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChargerNiveau () {
		SceneManager.LoadScene("Level02");
	}

	public void Quitter(){
		Application.Quit ();
	}
}
