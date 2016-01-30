using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
	public bool autoCollect = true;
	public float throwSpeed = 10f;
	public float slowPercentage = .1f;
	public float timeEffect = .0f;
	public int point = 0;
	public int eatPoint = 10;
	public float strikeTime = .0f;

	public GameObject owner;

	Vector3 movement = new Vector3 (0, 0, 0);
	float currentTime = .0f;

	// Update is called once per frame
	void FixedUpdate () {
		if (currentTime >= .0f) {
			currentTime -= Time.deltaTime;
			if (currentTime <= 0) {
				GetComponent<BoxCollider2D> ().isTrigger = true;
			}
		}
		transform.Translate (movement * Time.deltaTime);
		movement *= slowPercentage;
	}

	public void Throw(bool right, bool left, bool top, bool bottom, float strikeMultiplicater) {
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

		GetComponent<BoxCollider2D> ().isTrigger = false;
		currentTime = strikeTime * strikeMultiplicater;
	}

	public bool isCollectable() {
		return currentTime < 0;
	}
}
