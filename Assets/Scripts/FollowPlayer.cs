using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	// Update is called once per frame
	void FixedUpdate () {
		float x = (player1.transform.position.x + player2.transform.position.x) / 2;
		float y = (player1.transform.position.y + player2.transform.position.y) / 2;
		transform.position = new Vector3(x, y, transform.position.z);

		float size = Mathf.Abs (player2.transform.position.x - player1.transform.position.x + player2.transform.position.y - player1.transform.position.y);
		float potentialCameraSize = size;
		if (potentialCameraSize < 2) {
			potentialCameraSize = 2;
		} else if (potentialCameraSize > 10) {
			potentialCameraSize = 10;
		}
		Camera.main.orthographicSize = potentialCameraSize;
	}
}
