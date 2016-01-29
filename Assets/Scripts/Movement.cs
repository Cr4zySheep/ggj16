using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public KeyCode codeHaut = KeyCode.Z;
	public KeyCode codeBas = KeyCode.S;
	public KeyCode codeDroite = KeyCode.D;
	public KeyCode codeGauche = KeyCode.Q;
	public KeyCode codeSprint = KeyCode.LeftShift;
	public KeyCode codePositif = KeyCode.E;
	public KeyCode codeNegatif = KeyCode.R;
	public float initialSpeed = 2;
	private float currentSpeed;
	private Vector3 mouvement;
	Component spriteOriginal;
	public Sprite Avecunobjet;


	// Use this for initialization
	void Start () {
		spriteOriginal = GetComponent<SpriteRenderer>();
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

		if (Input.GetKeyDown (codePositif)) {
			Debug.Log("Interaction positive");
			GetComponent<SpriteRenderer>().sprite = Avecunobjet;
		}

		transform.Translate (mouvement * Time.deltaTime);

	}
}
