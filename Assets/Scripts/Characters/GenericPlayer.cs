using UnityEngine;
using System.Collections;
using System;
using InControl;

public class GenericPlayer : MonoBehaviour
{

	// Moving
	public float force = 150f;
	public float slowDown = 0.95f;
	public float maxSpeed = 10f;

	protected bool facingRight = true;

	// Jumping
	public float jumpPower = 40f;
	protected bool jumpPressed = false;
	protected bool firstJump = false;
	protected bool secondJump = false;
	private Transform groundCheck;

	// Main Attack
	public float mainAttackCooldown = 0.25f;
	protected bool attacking = false;
	private float mainAttackCooldownCounter = 0f;

	// Objects
	protected Rigidbody2D body;
	protected new BoxCollider2D collider;
	protected BoxCollider2D attackCollider;
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

		//Attacking
		attackCollider = GameObject.Find("attackCollider").GetComponent<BoxCollider2D>();
	}

	void Awake()
	{
		
	}

	// Update is called once per frame
	protected void FixedUpdate()
	{
		if (isGrounded())
		{
			firstJump = false;
			secondJump = false;
		}
			
	}

	protected bool IsAnimationPlaying(string name)
	{
		return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
	}

	protected bool isGrounded()
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

	public void StopAttack()
	{
		attacking = false;
		mainAttackCooldownCounter = mainAttackCooldown;
	}

	protected void CheckAttack()
	{
		if (mainAttackCooldownCounter > 0)
			mainAttackCooldownCounter -= Time.deltaTime;

		if (InputManager.ActiveDevice.Action3.WasPressed && mainAttackCooldownCounter <= 0)
			attacking = true;
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

	public void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		facingRight = theScale.x > 0;
	}
}
