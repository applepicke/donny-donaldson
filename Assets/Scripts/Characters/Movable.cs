using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {

	protected bool facingRight = true;

	protected void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		facingRight = theScale.x > 0;
	}

	protected void FaceRight()
	{
		if (!facingRight)
			Flip();
	}

	protected void FaceLeft()
	{
		if (facingRight)
			Flip();
	}
}
