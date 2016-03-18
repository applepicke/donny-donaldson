using UnityEngine;
using System.Collections;
using System;

public class VampirePlayer : GenericPlayer {

	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected new void FixedUpdate () {
		Walk();
	}

	protected new void Walk()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");
		var body = GetComponent<Rigidbody2D>();

		var hVector = Vector2.right * horizontal * force;
		body.AddForce(hVector);
		
		var vVector = Vector2.up * vertical * force;
		body.AddForce(vVector);

		body.velocity *= slowDown;

		if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
			this.Flip();

	}

}
