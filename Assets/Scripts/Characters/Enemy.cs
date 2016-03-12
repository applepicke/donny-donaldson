using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private BoxCollider2D collider;
	private GameObject attackCollider;

	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<BoxCollider2D>();
		attackCollider = GameObject.Find("attackCollider");

		scoreManager = GameObject.Find("scoreManager").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		var attack = attackCollider.GetComponent<BoxCollider2D>();

		if (collider.bounds.Intersects(attack.bounds) && attack.enabled)
		{
			scoreManager.addScore(10f);
		}
	}

	void FixedUpdate()
	{
		
		
	}
}
