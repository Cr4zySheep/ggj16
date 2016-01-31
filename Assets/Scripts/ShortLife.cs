using UnityEngine;
using System.Collections;

public class ShortLife : MonoBehaviour {
	public GameObject player;

	float p;
	float leftTime;

	public void beginLife(float time) {
		leftTime = time;
		p = 0f;
	}

	void Update() {
		leftTime -= Time.deltaTime;
		p += Time.deltaTime;

		if (p >= 1f) {
			GetComponent<Score> ().addScore (-3 * (int)(p));
			p -= (int)p;
		}

		if (leftTime <= 0) {
			GameObject obj = Instantiate (player);
			obj.transform.position = transform.position;
			obj.GetComponent<Score> ().label = GetComponent<Score> ().label;
			obj.GetComponent<Animator> ().SetTrigger ("FallAsleep");

			if (Camera.main.GetComponent<FollowPlayer> ().player1 == gameObject) {
				Camera.main.GetComponent<FollowPlayer> ().player1 = obj;
			} else {
				Camera.main.GetComponent<FollowPlayer> ().player2 = obj;
			}

			Destroy (gameObject);
		}
	}
}
