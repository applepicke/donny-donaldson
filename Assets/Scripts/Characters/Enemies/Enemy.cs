using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Movable {

	// Animations
	protected string deathAnimation;
	protected string walkingAnimation;

	// Taking Damage
	public float health;
	private bool dead = false;

	// Movement
	public float moveSpeed;

	// Scoring
	protected ScoreManager scoreManager;

	// Object References
	protected Rigidbody2D body;
	protected GameObject player;
	protected Animator animator;

	protected GameObject[] weapons;
	protected new BoxCollider2D collider;

	protected Blood blood;

	// Use this for initialization
	protected void Start () {
		scoreManager = GameObject.Find("scoreManager").GetComponent<ScoreManager>();
		body = gameObject.GetComponent<Rigidbody2D>();
		player = GameObject.Find("donny_teen");
		animator = gameObject.GetComponent<Animator>();

		weapons = GameObject.FindGameObjectsWithTag("Weapon");
		collider = gameObject.GetComponent<BoxCollider2D>();

		blood = transform.Find("blood").gameObject.GetComponent<Blood>();
	}

	// Update is called once per frame
	protected void Update () {

		if (!dead)
		{
			CheckAttackCollisions();
			CheckDead();
		}
		
	}

	protected void FixedUpdate()
	{

		if (!dead)
		{
			Move();
		}
		
	}

	public bool IsDead()
	{
		return dead;
	}

	protected void CheckDead()
	{
		if (health <= 0)
		{
			dead = true;

			Debug.Log(deathAnimation);

			animator.Play(deathAnimation, -1, 0f);
		}
	}

	protected void CheckAttackCollisions()
	{
		foreach (GameObject weaponObj in weapons)
		{
			var attackCollider = weaponObj.GetComponent<BoxCollider2D>();
			var weapon = weaponObj.GetComponent<Weapon>();

			if (!weapon.IsCool())
				continue;

			if (collider.bounds.Intersects(attackCollider.bounds) && attackCollider.enabled)
			{
				TakeHit(weapon);
			}
		}

		
	}

	protected void TakeHit(Weapon weapon)
	{
		blood.Bleed();
		weapon.Warm();

		// TODO: Figure out which body part is hit
		scoreManager.HitBody();

		health -= weapon.damage;
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
