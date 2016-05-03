using UnityEngine;
using System.Collections;

public class Door : Activatable {

	private EdgeCollider2D edgeCollider;

	protected new void Start()
	{
		base.Start();
		edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
	}

	public override void PostOpen()
	{
		edgeCollider.enabled = false;
	}

}
