using UnityEngine;
using System.Collections;

public class Possession : MonoBehaviour {

	public bool possessed;
	// a passer en prive

	void setPossessed(bool b){
		this.possessed = b;
	}

	bool getPossessed(){
		return this.possessed;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
