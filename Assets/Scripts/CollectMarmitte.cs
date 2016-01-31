using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectMarmitte : MonoBehaviour {
	public Image img;
	public Slider slider;
	public Color flash;
	public GameObject victory;

	AudioSource source;
	float currentTime = 0;

	void Awake() {
		source = GetComponent<AudioSource> ();
	}

	void Update() {
		if (currentTime < 1) {
			img.color = Color.Lerp (flash, new Color (255, 255, 255, 0), currentTime);
			currentTime += Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Collectable collectable = collider.GetComponent<Collectable> ();
		if (collectable) {
			if(collectable.owner) collectable.owner.GetComponent<Score> ().addScore (collectable.point);
			Chronometre.tempsRestant += collectable.timeEffect;
			slider.value += collectable.eatPoint;
			Destroy (collider.gameObject);
			currentTime = 0;

			source.Play ();


			if (slider.value >= slider.maxValue) {
				victory.SetActive (true);
			}
		}
	}
}
