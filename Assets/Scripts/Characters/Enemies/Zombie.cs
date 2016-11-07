using UnityEngine;
using System.Collections;

public class Zombie : Enemy {

	// Use this for initialization
	protected new void Start ()
	{
		base.Start();
		walkingAnimation = "zombie_walking";
		deathAnimation = "zombie_dying";
	}
	
	// Update is called once per frame
	protected new void Update ()
	{
		base.Update();
	}

	protected new void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
