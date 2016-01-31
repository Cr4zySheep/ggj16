using UnityEngine;
using System.Collections;

public class Readiness : MonoBehaviour {

	public Transform camera;
	public KeyCode r1 = KeyCode.F;
	public KeyCode r2 = KeyCode.Alpha9;
	public KeyCode r2bis = KeyCode.JoystickButton1;
	public GameObject timer1;
	public GameObject timer2;
	public GameObject player1;
	public GameObject player2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player1.SetActive (false);
		player2.SetActive (false);
		timer1.SetActive (false);
		timer2.SetActive (false);
		gameObject.transform.position = new Vector3 ((camera.position.x+3f),(camera.position.y+1.7f),gameObject.transform.position.z);
		if (Input.GetKey (r1)){
			GameObject.Find("p1red").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("p1green").GetComponent<SpriteRenderer>().enabled = true;
		}
		if (Input.GetKey (r2)||Input.GetKey (r2bis)){
			Debug.Log ("ok");
			GameObject.Find("p2red").GetComponent<SpriteRenderer>().enabled = false;
			GameObject.Find("p2green").GetComponent<SpriteRenderer>().enabled = true;
		}
		if (GameObject.Find("p1green").GetComponent<SpriteRenderer>().enabled == true && GameObject.Find("p2green").GetComponent<SpriteRenderer>().enabled == true){
			player1.SetActive (true);
			player2.SetActive (true);
			timer1.SetActive (true);
			timer2.SetActive (true);
			Object.Destroy (this.gameObject);
		}

	}
}
