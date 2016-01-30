using UnityEngine;
using System.Collections;

public class CollectMarmitte : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider) {
		Collectable collectable = collider.GetComponent<Collectable> ();
		if (collectable) {
			Destroy (collider.gameObject);
		}
	}
}
