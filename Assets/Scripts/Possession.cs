using UnityEngine;
using System.Collections;

public class Possession : MonoBehaviour {
	public GameObject demon;

	void Awake() {
		PossessionTimer.demons.Add (this);
	}

	public void beginPossession(float time) {
		GameObject obj = Instantiate (demon);
		obj.transform.position = transform.position;
		obj.GetComponent<ShortLife> ().beginLife (time);
		Destroy (gameObject);
	}
}
