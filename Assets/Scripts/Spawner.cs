using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject objToSpawn;
	public Transform leftTopCorner;
	public Transform rightBottomCorner;
	public float timeBetweenSpawn = 30f;

	float time = 0f;
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= timeBetweenSpawn) {
			GameObject obj = Instantiate (objToSpawn);
			float x = Random.Range (leftTopCorner.position.x, rightBottomCorner.position.x);
			float y = Random.Range (rightBottomCorner.position.y, leftTopCorner.position.y);

			while (Physics2D.OverlapCircle (new Vector2 (x, y), 0.5f)) {
				x = Random.Range (leftTopCorner.position.x, rightBottomCorner.position.x);
				y = Random.Range (rightBottomCorner.position.y, leftTopCorner.position.y);
			}

			obj.transform.position = new Vector3 (x, y, 0);
			time = 0f;
		}
	}
}
