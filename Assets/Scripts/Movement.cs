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
	public float speed = 2;
	public Vector3 mouvement;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		mouvement = new Vector3 (0, 0, 0);

		if (Input.GetKey (codeHaut)) {
			mouvement += new Vector3 (0, speed, 0);
		}
		if (Input.GetKey (codeBas)) {
			mouvement += new Vector3 (0, -speed, 0);
		}
		if (Input.GetKey (codeDroite)) {
			mouvement += new Vector3 (speed, 0, 0);
		}
		if (Input.GetKey (codeGauche)) {
			mouvement += new Vector3 (-speed, 0, 0);
		}
		transform.Translate (mouvement * Time.deltaTime);
	}
}
