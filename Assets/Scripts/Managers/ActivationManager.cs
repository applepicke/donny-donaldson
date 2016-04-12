using UnityEngine;
using System.Collections;
using InControl;

public class ActivationManager : MonoBehaviour {

	private float timeHeld = 0f;

	private ConfigManager config;
	private GameObject b_button;
	private GameObject player;

	// Use this for initialization
	void Start () {
		b_button = GameObject.Find("b_button");
		player = GameObject.Find("donny");

		config = GameObject.Find("configManager").GetComponent<ConfigManager>();

		HideButton();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool CheckButton(InputControl device, float time)
	{
		if (device.IsPressed)
			timeHeld += Time.deltaTime;
		else
			timeHeld = 0f;

		if (timeHeld >= time)
		{
			timeHeld = 0f;
			return true;
		}
		return false;
	}

	public bool CheckStick(InputControl device, float time)
	{
		if (device.Value > 0.9)
			timeHeld += Time.deltaTime;
		else
			timeHeld = 0f;

		if (timeHeld >= time)
		{
			timeHeld = 0f;
			return true;
		}
		return false;
	}

	public void ShowArrow()
	{

	}

	public void ShowButton()
	{
		var targetTransform = player.GetComponent<Transform>().Find("ideaSpace");
		var buttonTransform = b_button.GetComponent<Transform>();

		buttonTransform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, 0);
		b_button.SetActive(true);
	}

	public void HideButton()
	{
		if (b_button.activeSelf)
			b_button.SetActive(false);
	}
}
