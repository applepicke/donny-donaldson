using UnityEngine;
using System.Collections;

public class Blood : MonoBehaviour {

	// Animation
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		Hide();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Bleed()
	{
		gameObject.SetActive(true);
		animator.Play("blood_body_jab", 0, 0f);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}
}
