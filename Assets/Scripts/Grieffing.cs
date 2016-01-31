using UnityEngine;
using System.Collections;

public class Grieffing : MonoBehaviour {
	public KeyCode attackKey;
	public float stonedTime = .5f;
	public float reloadTime = .5f;
	public GameObject hitPoint;
	public int joystick;
	public AudioClip clip;

	AudioSource source;
	Animator anim;
	float currentStonedTime = 0;
	float currentReloadTime = 0;

	void Awake() {
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
	}

	void Update() {
		if (currentReloadTime >= 0) {
			currentReloadTime -= Time.deltaTime;
		}

		if (currentStonedTime >= 0) {
			currentStonedTime -= Time.deltaTime;
			if (currentStonedTime < 0) {
				GetComponent<Movement> ().enabled = true;
			}
		}

	}

	void OnTriggerStay2D(Collider2D collider) {
		Grieffing grieffing = collider.gameObject.GetComponent<Grieffing> ();
		if (grieffing && (Input.GetKey(attackKey) || Input.GetAxis("A" + joystick.ToString()) > 0) && currentReloadTime < 0) {
			if (GetComponent<ShortLife> ()) {
				collider.gameObject.GetComponent<Score> ().addScore (-5);
				GetComponent<Score> ().addScore (2);
			}
			source.clip = clip;
			source.Play ();
			currentReloadTime = reloadTime;
			Instantiate (hitPoint, (transform.position + collider.transform.position) / 2, new Quaternion());
			grieffing.hurt (stonedTime);
			anim.SetTrigger ("Fight");
		}
	}

	void hurt(float time) {
		currentStonedTime = time;
		GetComponent<Movement> ().enabled = false;
	}
}
