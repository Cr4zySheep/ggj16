using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {
	public KeyCode passif = KeyCode.A;
	public KeyCode actif = KeyCode.E;

	GameObject obj = null;
	bool changed = false;

	Vector3 lastPos;

	void FixedUpdate() {
		if (obj) {
			obj.transform.position = transform.position;
		}
	}

	void Update() {
		if (!changed && obj) {
			//On le pose
			if (Input.GetKeyDown (passif)) {
				obj.GetComponent<Collectable> ().owner = null;
				obj = null;
			}
			//On le jete
			if (Input.GetKeyDown (actif)) {
				Vector3 moving = transform.position - lastPos;
				obj.GetComponent<Collectable> ().Throw (moving.x > 0, moving.x < 0, moving.y > 0, moving.y < 0);
				obj = null;
			}
		} else {
			changed = false;
		}

		lastPos = transform.position;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Collectable collectable = collider.GetComponent<Collectable> ();

		//Si c'est un objet collectable et qu'on porte rien
		if (collectable) {
			//Si auto collect
			if (collectable.autoCollect || Input.GetKeyDown (passif)) {
				collectObject (collider.gameObject);
			}
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		if (Input.GetKeyDown (passif)) {
			collectObject (collider.gameObject);
		}
	}

	void collectObject(GameObject collectingObj) {
		if (!obj) {
			obj = collectingObj.gameObject;
			obj.transform.position = transform.position;
			obj.GetComponent<Collectable> ().owner = gameObject;
			changed = true;
		}
	}
}
