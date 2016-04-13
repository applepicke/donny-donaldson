using UnityEngine;
using System.Collections;
using InControl;
using System.Collections.Generic;

public class IdeaManager : MonoBehaviour {

	private ConfigManager config;
	private GameObject player;

	// Hover displays
	[HideInInspector]
	public Idea downIdea;
	[HideInInspector]
	public Idea activateIdea;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("donny");
		config = GameObject.Find("configManager").GetComponent<ConfigManager>();

		downIdea = GameObject.Find("downIdea").GetComponent<Idea>();
		activateIdea = GameObject.Find("activateIdea").GetComponent<Idea>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HideAll()
	{
		downIdea.Hide();
		activateIdea.Hide();
	}

	

}
