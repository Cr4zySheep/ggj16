using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public KeyCode codeHaut = KeyCode.Z;
	public KeyCode codeBas = KeyCode.S;
	public KeyCode codeDroite = KeyCode.D;
	public KeyCode codeGauche = KeyCode.Q;
	public KeyCode codeSprint = KeyCode.LeftShift;
	public int joystick;
	public float initialSpeed = 2;
	public AudioClip clip;

	AudioSource source;
	Animator anim;
	float currentSpeed;
	Vector3 mouvement;
	public bool glace;
	private int vitesseDeGlisse;


	// Use this for initialization
	void Awake () {
		currentSpeed = initialSpeed;
		glace = false;
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.GetComponent<Glissement>()) {
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

		if (Input.GetKey (codeHaut) || Input.GetAxis("V" + joystick.ToString()) > 0) {
			mouvement += new Vector3 (0, currentSpeed, 0);
			anim.SetTrigger ("GoUp");
		}
		if (Input.GetKey (codeBas) || Input.GetAxis("V" + joystick.ToString()) < 0) {
			mouvement += new Vector3 (0, -currentSpeed, 0);
			anim.SetTrigger ("GoBottom");
		}
		if (Input.GetKey (codeDroite) || Input.GetAxis("H" + joystick.ToString()) > 0) {
			mouvement += new Vector3 (currentSpeed, 0, 0);
			anim.SetTrigger ("GoRight");
		}
		if (Input.GetKey (codeGauche) || Input.GetAxis("H" + joystick.ToString()) < 0) {
			mouvement += new Vector3 (-currentSpeed, 0, 0);
			anim.SetTrigger ("GoLeft");
		}

		if (mouvement == new Vector3 (0, 0, 0)) {
			anim.SetTrigger ("Stop");
		} else {
			if (!source.isPlaying) {
				source.clip = clip;
				source.Play ();
			}
			if (Input.GetKey (codeSprint) || Input.GetAxis ("S" + joystick.ToString ()) > 0) {
				mouvement *= 2;
			}
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
