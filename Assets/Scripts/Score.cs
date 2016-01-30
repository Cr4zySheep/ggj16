using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text label;
	public int score;

	// Use this for initialization
	void Awake () {
		score = 0;
	}

	public void addScore(int many) {
		score += many;
		if (score < 0) {
			score = 0;
		}

		label.text = score.ToString();
	}
}
