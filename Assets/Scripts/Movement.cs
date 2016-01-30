﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public KeyCode codeHaut = KeyCode.Z;
	public KeyCode codeBas = KeyCode.S;
	public KeyCode codeDroite = KeyCode.D;
	public KeyCode codeGauche = KeyCode.Q;
	public KeyCode codeSprint = KeyCode.LeftShift;
	public float initialSpeed = 2;
	float currentSpeed;
	Vector3 mouvement;
	Component spriteOriginal;
	public Sprite Avecunobjet;
	public bool glace;
	private int vitesseDeGlisse;


	// Use this for initialization
	void Start () {
		spriteOriginal = GetComponent<SpriteRenderer>();
		glace = false;
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.GetComponent<Glissement>() == null) {
			// Rien
		} else {
			glace = true;
			vitesseDeGlisse = collider.GetComponent<Glissement>().coefficient;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		glace = false;
	}
	// Update is called once per frame
	void FixedUpdate () {
		mouvement = new Vector3 (0, 0, 0);
		currentSpeed = initialSpeed;
		if (Input.GetKey (codeSprint)) {
			currentSpeed=2*currentSpeed;
		}
		if (Input.GetKey (codeHaut)) {
			mouvement += new Vector3 (0, currentSpeed, 0);
		}
		if (Input.GetKey (codeBas)) {
			mouvement += new Vector3 (0, -currentSpeed, 0);
		}
		if (Input.GetKey (codeDroite)) {
			mouvement += new Vector3 (currentSpeed, 0, 0);
		}
		if (Input.GetKey (codeGauche)) {
			mouvement += new Vector3 (-currentSpeed, 0, 0);
		}

		if (glace) {
			// Ajoute l'inertie sur la glace
			GetComponent<Rigidbody2D> ().AddForce (mouvement * Time.deltaTime * vitesseDeGlisse);
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);
		}

		//Bouge le joueur pour la frame
		transform.Translate (mouvement * Time.deltaTime);
	}
}
