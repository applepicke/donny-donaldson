using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		Animate();

	}

	// Attacking
	public void setAttackCollider(int stage)
	{
		/*
		switch (stage) {
			case 0:
				attackCollider.offset = new Vector2(-0.3514208f, 0.07911479f);
				attackCollider.size = new Vector2(0.4357498f, 0.03979646f);
				break;
			case 1:
				attackCollider.offset = new Vector2(-0.5085995f, 0.1079786f);
				attackCollider.size = new Vector2(0.4845567f, 0.04541113f);
				break;
			case 2:
				attackCollider.offset = new Vector2(-0.5085995f, 0.1079786f);
				attackCollider.size = new Vector2(0.4845567f, 0.04541113f);
				break;
			default:
				break;
		}
		*/
	}

	protected void Animate()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		// Look up 
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("donny_look_up"))
			cameraManager.LookUp();
		else
			cameraManager.LookNormal();

		// Animations
		if (attacking)
			animator.CrossFade("donny_attack_overhead", 0f);
		else if (firstJump)
			animator.CrossFade("donny_jump", 0f);
		else if (h < 0.5f && h > -0.5f)
		{
			if (v > 0.5f)
			{
				animator.CrossFade("donny_look_up", 0f);
				cameraManager.LookUp();
			}
			else if (v < -0.5f)
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

		// Movement
		if (body.velocity.magnitude < maxSpeed)
		{
			var forceVector = Vector2.right * h * force;
			body.AddForce(forceVector);
		}
	
		body.velocity *= slowDown;

		if (body.velocity.sqrMagnitude < 0.01f)
			body.velocity = Vector2.zero;
			
		if (h < 0 && facingRight || h > 0 && !facingRight)
			this.Flip();
	}

}
