using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	public bool autoCollect = true;
	public float throwSpeed = 10f;
	public float slowPercentage = .1f;

	Vector3 movement = new Vector3 (0, 0, 0);

	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (movement * Time.deltaTime);
		movement *= slowPercentage;
	}

	public void Throw(bool right, bool left, bool top, bool bottom) {
		movement = new Vector3(0, 0, 0);

		if(right) {
			movement += new Vector3(throwSpeed, 0, 0);
		} else if(left) {
			movement += new Vector3(-throwSpeed, 0, 0);
		}

		if(top) {
			movement += new Vector3(0, throwSpeed, 0);
		} else if(bottom) {
			movement += new Vector3(0, -throwSpeed, 0);
		}
	}
}
