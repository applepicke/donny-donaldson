using UnityEngine;
using System.Collections;

public class Enemy : Movable {

	// Taking Damage
	public float cooldown;
	private float cooldownCounter;

	// Movement
	public float moveSpeed;

	// Scoring
	protected ScoreManager scoreManager;

	// Object References
	protected Rigidbody2D body;
	protected GameObject player;

	protected BoxCollider2D attackCollider;
	protected new BoxCollider2D collider;

	protected GameObject blood;

	// Use this for initialization
	protected void Start () {
		scoreManager = GameObject.Find("scoreManager").GetComponent<ScoreManager>();
		body = gameObject.GetComponent<Rigidbody2D>();
		player = GameObject.Find("donny_teen");

		attackCollider = GameObject.Find("attackCollider").GetComponent<BoxCollider2D>();
		collider = gameObject.GetComponent<BoxCollider2D>();

		blood = transform.Find("blood").gameObject;
	}
	
	// Update is called once per frame
	protected void Update () {

		CheckAttackCollisions();
		
	}

	protected void FixedUpdate()
	{
		Move();	
	}

	protected void CheckAttackCollisions()
	{
		var attack = attackCollider.GetComponent<BoxCollider2D>();

		if (cooldownCounter > 0)
		{
			cooldownCounter -= Time.deltaTime;
			return;
		}
			

		if (collider.bounds.Intersects(attack.bounds) && attack.enabled)
		{
			cooldownCounter = cooldown;
			blood.SetActive(true);
			scoreManager.addScore(10f);
		}
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
