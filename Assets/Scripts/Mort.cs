using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mort : MonoBehaviour {
	public GameObject tombstone;

	Vector3 deadPos;
	float tempsSpawn;
	bool chrono;
	
	// Update is called once per frame
	void Update () {
		if (chrono) {
			tempsSpawn += Time.deltaTime;
			transform.position = deadPos;
			//txtRespawn.text="Your adept died!\nAnother one will take his place\nIn "+(3-(int)tempsSpawn)+" ...";
		}
		if ((int)tempsSpawn == 3) {
			chrono = false;
			tempsSpawn = 0;
			//lblRespawn.SetActive (false);
			GetComponent<SpriteRenderer> ().enabled = true;
			GetComponent<BoxCollider2D> ().enabled = true;
			gameObject.transform.position = new Vector3 (0, 0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Mort") && GetComponent<Movement>().enabled) {
			kill ();
		}
	}

	public void kill() {
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<Score> ().addScore (-15);
		deadPos = transform.position;
		//lblRespawn.SetActive (true);
		//txtRespawn.text="Your adept died!\nAnother one will take his place\nIn 3 ...";
		chrono = true;
		Instantiate (tombstone, transform.position, new Quaternion());
	}
}
