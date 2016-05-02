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
	[HideInInspector]
	public Idea upIdea;
	[HideInInspector]
	public Idea rightIdea;
	[HideInInspector]
	public Idea leftIdea;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("donny");
		config = GameObject.Find("configManager").GetComponent<ConfigManager>();

		HideAll();
	}

	void Awake()
	{
		downIdea = GameObject.Find("downIdea").GetComponent<Idea>();
		activateIdea = GameObject.Find("activateIdea").GetComponent<Idea>();
		upIdea = GameObject.Find("upIdea").GetComponent<Idea>();
		rightIdea = GameObject.Find("rightIdea").GetComponent<Idea>();
		leftIdea = GameObject.Find("leftIdea").GetComponent<Idea>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HideAll()
	{
		downIdea.Hide();
		activateIdea.Hide();
		upIdea.Hide();
		rightIdea.Hide();
		leftIdea.Hide();
	}

	

}
