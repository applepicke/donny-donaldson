using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TeenPlayer : GenericPlayer {
	
	protected void Update()
	{
		CheckJump();
		CheckAttack();
	}

	// Update is called once per frame
	protected new void FixedUpdate() {
		base.FixedUpdate();
		Jump();
		Walk();

		if (!attacking)
			Animate();
	}

	// Attacking
	public void setAttackCollider(int stage)
	{

	}

	protected void Animate()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		var is_running = h < 0.5f && h > -0.5f;
		var is_looking_up = v > 0.5f;
		var is_looking_down = v < -0.5f;

		// Look up 
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("donny_look_up"))
			cameraManager.LookUp();
		else
			cameraManager.LookNormal(); 


		if (firstJump)
			animator.CrossFade("donny_jump", 0f);
		else if (landing)
			animator.CrossFade("donny_land", 0f);
		else if (is_running)
		{
			if (is_looking_up)
			{
				animator.CrossFade("donny_look_up", 0f);
				cameraManager.LookUp();
			}
			else if (is_looking_down)
			{
				animator.CrossFade("donny_duck", 0f);
				cameraManager.LookDown();
			}
			else
				animator.CrossFade("donny_idle", 0f);

		}
		else
			animator.CrossFade("donny_running", 0f);
	}

	protected new void Walk()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		var localForce = force;
		var currentVelocity = body.velocity.magnitude;

		localForce *= (maxVelocity - currentVelocity) / maxVelocity;

		if (!IsGrounded())
			localForce = force * airSlowdown;

		var forceVector = Vector2.right * h * localForce;
		body.AddForce(forceVector);
	
		body.velocity *= slowDown;

		if (body.velocity.sqrMagnitude < 0.01f)
			body.velocity = Vector2.zero;
			
		if (h < 0 && facingRight || h > 0 && !facingRight)
			this.Flip();
	}

}
