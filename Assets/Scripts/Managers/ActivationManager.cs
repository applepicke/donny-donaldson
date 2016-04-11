using UnityEngine;
using System.Collections;

public class ActivationManager : MonoBehaviour {

	private GameObject b_button;
	private GameObject player;

	// Use this for initialization
	void Start () {
		b_button = GameObject.Find("b_button");
		player = GameObject.Find("donny");

		HideButton();
	}
	
	// Update is called once per frame
	void Update () {
	
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
