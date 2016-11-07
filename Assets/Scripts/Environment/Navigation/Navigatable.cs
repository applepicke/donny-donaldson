using UnityEngine;
using System.Collections;
using InControl;

public class Navigatable : Activatable
{
	public GameObject destination;

	protected Idea navigateIdea;

	// Use this for initialization
	protected new void Start()
	{
		base.Start();
		animator = gameObject.GetComponent<Animator>();

		config = GameObject.Find("configManager").GetComponent<ConfigManager>();
		ideaManager = GameObject.Find("ideaManager").GetComponent<IdeaManager>();
		navManager = GameObject.Find("navManager").GetComponent<NavigationManager>();
		player = GameObject.Find("donny");

		activateIdea = ideaManager.activateIdea;
		navigateIdea = ideaManager.downIdea;
	}

	// Update is called once per frame
	protected new void Update()
	{
		base.Update();

		if (IsPlayerInProximity())
		{
			wasInProximity = true;

			if (open)
			{
				navigateIdea.Show();
				if (navigateIdea.CheckStick(GetStick(), config.dropDownTime))
					Transport();
			}
		}
	}

	private bool IsPlayerInProximity()
	{
		var inRange = Ranges.InRange(player.GetComponent<Transform>(), transform, config.activationRange);
		return inRange;
	}

	public override void PostOpen()
	{
		GetDestination().Open();
	}

	protected Navigatable GetDestination()
	{
		return destination.GetComponent<Navigatable>();
	}

	public virtual void Transport() { }
	protected virtual InputControl GetStick() {return null;}
}
