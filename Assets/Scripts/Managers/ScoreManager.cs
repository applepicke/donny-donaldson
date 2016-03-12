using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private float playerScore;

	public float minorScore = 10f;
	public float mediumScore = 30f;
	public float majorScore = 100f;

	private Text scoreUI; 

	// Use this for initialization
	void Start () {
		playerScore = 0f;
		scoreUI = GameObject.Find("Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		scoreUI.text = playerScore.ToString();
	}

	public void addScore(float value)
	{
		playerScore += value;

		// TODO: Show cool score popup somewhere
	}
}
