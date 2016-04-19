using UnityEngine;
using System.Collections;
using InControl;

public class Idea : MonoBehaviour {

	private float timeHeld = 0f;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("donny");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		var targetTransform = player.GetComponent<Transform>().Find("ideaSpace");
		transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, 0);
		gameObject.SetActive(true);
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
}
