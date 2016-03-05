using UnityEngine;
using System.Collections;
using System;

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

	protected Rigidbody2D body;
	private new BoxCollider2D collider;

	protected Animator animator;
	protected CameraManager cameraManager;

	// Use this for initialization
	void Start()
	{	
	}

	void Awake()
	{
		body = gameObject.GetComponent<Rigidbody2D>();
		collider = gameObject.GetComponent<BoxCollider2D>();
		groundCheck = transform.Find("groundCheck");
		animator = transform.GetComponent<Animator>();
		cameraManager = GameObject.Find("player_camera").GetComponent<CameraManager>();
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

	protected bool isGrounded()
	{
		return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}

	protected void CheckJump()
	{
		if (Input.GetButtonDown("Jump"))
			jumpPressed = true;

		if (Input.GetButtonUp("Jump"))
			jumpPressed = false;
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
