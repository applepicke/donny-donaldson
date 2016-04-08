using UnityEngine;
using System.Collections;
using InControl;

public class Trapdoor : MonoBehaviour {

	private float timeHeld = 0f;
	private bool open = false;

	//Objects
	private ConfigManager config;
	private Animator animator;
	private GameObject player;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
		config = GameObject.Find("configManager").GetComponent<ConfigManager>();
		player = GameObject.Find("donny");
	}
	
	// Update is called once per frame
	void Update () {

		if (IsPlayerInProximity())
		{
			CheckOpening();
		}
	}

	private void CheckOpening()
	{
		if (InputManager.ActiveDevice.Action2.IsPressed)
			timeHeld += Time.deltaTime;
		else
			timeHeld = 0f;

		if (timeHeld >= config.keyHoldTime)
		{
			timeHeld = 0f;
			Open();
		}

	}

	private bool IsPlayerInProximity()
	{
		return Ranges.InRange(player.GetComponent<Transform>(), transform, config.activationRange);
	}

	public void Close()
	{
		open = false;
		animator.CrossFade("trapdoor_closed", 0f);
	}

	public void Open()
	{
		open = true;
		animator.CrossFade("trapdoor_open", 0f);
	}
}
