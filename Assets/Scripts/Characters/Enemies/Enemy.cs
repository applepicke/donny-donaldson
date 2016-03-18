using UnityEngine;
using System.Collections;

public class Enemy : Movable {

	// Movement
	public float moveSpeed;

	// Scoring
	protected ScoreManager scoreManager;

	// Object References
	protected Rigidbody2D body;
	protected GameObject player;

	// Use this for initialization
	protected void Start () {
		scoreManager = GameObject.Find("scoreManager").GetComponent<ScoreManager>();
		body = gameObject.GetComponent<Rigidbody2D>();
		player = GameObject.Find("donny_teen");
	}
	
	// Update is called once per frame
	protected void Update () {
		/*
		var attack = attackCollider.GetComponent<BoxCollider2D>();

		if (collider.bounds.Intersects(attack.bounds) && attack.enabled)
		{
			scoreManager.addScore(10f);
		}
		*/
	}

	protected void FixedUpdate()
	{
		Move();
		
	}

	protected void Move()
	{
		var currentVelocity = body.velocity.magnitude;

		var follow = player.GetComponent<Transform>();

		if (follow.position.x > transform.position.x)
			FaceRight();
		else
			FaceLeft();

		var flip = facingRight ? 1 : -1;

		var forceVector = Vector2.right * moveSpeed * flip;
		body.velocity = forceVector;
	}
}
