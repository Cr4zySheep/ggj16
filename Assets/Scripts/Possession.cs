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
		obj.GetComponent<Score> ().label = GetComponent<Score> ().label;

		if (Camera.main.GetComponent<FollowPlayer> ().player1 == gameObject) {
			Camera.main.GetComponent<FollowPlayer> ().player1 = obj;
		} else {
			Camera.main.GetComponent<FollowPlayer> ().player2 = obj;
		}

		Destroy (gameObject);
	}
}
