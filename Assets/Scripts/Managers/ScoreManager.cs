using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private float playerScore;

	public float bodyHit;

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

	public void HitBody()
	{
		AddScore(bodyHit);
	}

	public void AddScore(float value)
	{
		playerScore += value;

		// TODO: Show cool score popup somewhere
	}
}
