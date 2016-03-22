using UnityEngine;
using System.Collections;
using System;
using InControl;

public class GenericPlayer : Movable
{
	// Animations
	protected bool canChangeAnimation = true;

	// Moving
	public float force = 150f;
	public float slowDown = 0.95f;
	public float maxVelocity = 10f;
	public float airSlowdown = 0.5f;

	// Jumping
	public float jumpPower = 40f;
	protected bool jumpPressed = false;
	protected bool firstJump = false;
	protected bool secondJump = false;
	protected bool landing = false;
	private Transform groundCheck;

	// Sword Attack
	public float attackChargeTime = 0f;
	private float attackCharge = 2f;

	protected bool overheadAttack = false;
	protected bool attacking = false;

	// Objects
	protected Rigidbody2D body;
	protected new BoxCollider2D collider;
	protected Animator animator;
	protected CameraManager cameraManager;

	// Use this for initialization
	void Start()
	{
		body = gameObject.GetComponent<Rigidbody2D>();
		collider = gameObject.GetComponent<BoxCollider2D>();
		groundCheck = transform.Find("groundCheck");
		animator = transform.GetComponent<Animator>();
		cameraManager = GameObject.Find("player_camera").GetComponent<CameraManager>();
	}

	void Awake()
	{
		
	}

	// Update is called once per frame
	protected void FixedUpdate()
	{
		if (IsGrounded())
		{
			if (firstJump)
				landing = true;

			firstJump = false;
			secondJump = false;
		}
			
	}

	protected bool IsAnimationPlaying(string name)
	{
		return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
	}

	protected bool IsGrounded()
	{
		return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}

	protected void CheckJump()
	{
		if (InputManager.ActiveDevice.Action1.WasPressed)
			jumpPressed = true;

		if (InputManager.ActiveDevice.Action1.WasReleased)
			jumpPressed = false;
	}

	public void StopLanding()
	{
		landing = false;
	}

	public void StopAttack()
	{
		attacking = false;
		overheadAttack = false;
		landing = false;
	}

	protected void AttackOverhead()
	{
		overheadAttack = true;
		animator.Play("donny_attack_overhead", -1, 0f);
	}

	protected void AttackJab()
	{
		animator.Play("donny_attack_jab", -1, 0f);
	}

	protected void CheckAttack()
	{

		if (InputManager.ActiveDevice.Action3.WasPressed)
			attackCharge = 0f;
		else
			attackCharge += Time.deltaTime;

		if (InputManager.ActiveDevice.Action3.WasReleased)
		{
			attacking = true;

			if (attackCharge >= attackChargeTime)
				AttackOverhead();
			else if (!overheadAttack)
				AttackJab();
		}
	}

	public void Jump()
	{
		if (jumpPressed && !secondJump)
		{
			jumpPressed = false;

			var velocity = new Vector2(body.velocity.x, 0);
			body.velocity = velocity;

			Vector2 force = (transform.up * jumpPower) / Time.fixedDeltaTime;
			body.AddForce(force);

			if (!firstJump)
				firstJump = true;
			else
				secondJump = true;
		}
	}

	protected void Walk()
	{

	}

	
}
