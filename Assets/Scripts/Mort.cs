using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mort : MonoBehaviour {

	float tempsSpawn;
	bool chrono;
	public GameObject lblRespawn;
	public Text txtRespawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (chrono) {
			tempsSpawn += Time.deltaTime;
			txtRespawn.text="Your adept died!\nAnother one will take his place\nIn "+(3-(int)tempsSpawn)+" ...";
		}
		if ((int)tempsSpawn == 3) {
			chrono = false;
			tempsSpawn = 0;
			lblRespawn.SetActive (false);
			GetComponent<Movement>().enabled = true;
			GetComponent<SpriteRenderer> ().enabled = true;
			GetComponent<BoxCollider2D> ().enabled = true;
			GetComponent<Grieffing> ().enabled = true;
			gameObject.transform.position = new Vector3 (0, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Mort")) {
			GetComponent<Movement>().enabled = false;
			GetComponent<SpriteRenderer> ().enabled = false;
			GetComponent<BoxCollider2D> ().enabled = false;
			GetComponent<Grieffing> ().enabled = false;
			lblRespawn.SetActive (true);
			txtRespawn.text="Your adept died!\nAnother one will take his place\nIn 3 ...";
			chrono = true;
		}
	}


}
