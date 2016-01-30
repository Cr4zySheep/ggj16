using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PossessionTimer : MonoBehaviour {
	public static List<Possession> demons = new List<Possession>();
	public float timeBetweenPossession = 30f;
	public float possessionTime = 15f;

	float nextPossession;

	void Awake() {
		nextPossession = timeBetweenPossession / 2;
	}

	void Update() {
		nextPossession -= Time.deltaTime;
		if (nextPossession <= 0f && demons.Count > 0) {
			demons [0].beginPossession (possessionTime);
			demons.RemoveAt (0);
			nextPossession = timeBetweenPossession;
		}
	}
}
