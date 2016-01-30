using UnityEngine;
using System.Collections;

public class CollectMarmitte : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider) {
		Collectable collectable = collider.GetComponent<Collectable> ();
		if (collectable) {
			collectable.owner.GetComponent<Score> ().addScore (collectable.point);
			Chronometre.tempsRestant += collectable.timeEffect;
			Destroy (collider.gameObject);
		}
	}
}
