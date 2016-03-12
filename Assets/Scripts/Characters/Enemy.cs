using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private BoxCollider2D collider;
	private GameObject attackCollider;

	// Use this for initialization
	void Start () {
		collider = gameObject.GetComponent<BoxCollider2D>();
		attackCollider = GameObject.Find("attackCollider");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		var attack = attackCollider.GetComponent<BoxCollider2D>();

		if (collider.bounds.Intersects(attack.bounds))
		{
			Debug.Log("HIT!");
		}
		
	}
}
