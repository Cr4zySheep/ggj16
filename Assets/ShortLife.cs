using UnityEngine;
using System.Collections;

public class ShortLife : MonoBehaviour {
	public GameObject player;
	float leftTime;

	public void beginLife(float time) {
		leftTime = time;
	}

	void Update() {
		leftTime -= Time.deltaTime;
		if (leftTime <= 0) {
			GameObject obj = Instantiate (player);
			obj.transform.position = transform.position;
			Destroy (gameObject);
		}
	}
}
