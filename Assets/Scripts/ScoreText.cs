using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    Text scoreText;

	// Use this for initialization
	void Start ()
    {
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	public void UpdateScore (int score)
    {
        scoreText.text = score.ToString();
	}
}
