using UnityEngine;
using System.Collections;
using InControl;

public class Navigatable : MonoBehaviour
{
	public GameObject destination;
	public GameObject room;

	private bool open = false;
	protected Idea activateIdea;
	protected Idea navigateIdea;

	//Objects
	protected IdeaManager ideaManager;
	protected ConfigManager config;
	protected Animator animator;
	protected GameObject player;
	protected NavigationManager navManager;


	// Use this for initialization
	protected void Start()
	{
		animator = gameObject.GetComponent<Animator>();

		config = GameObject.Find("configManager").GetComponent<ConfigManager>();
		ideaManager = GameObject.Find("ideaManager").GetComponent<IdeaManager>();
		navManager = GameObject.Find("navManager").GetComponent<NavigationManager>();
		player = GameObject.Find("donny");

		activateIdea = ideaManager.activateIdea;
		navigateIdea = ideaManager.downIdea;
	}

	// Update is called once per frame
	protected void Update()
	{
		if (!navManager.InRoom(room))
			return;

		if (IsPlayerInProximity())
		{

			if (!open)
			{
				activateIdea.Show();
				if (activateIdea.CheckButton(InputManager.ActiveDevice.Action2, config.activationTime))
					Open();
			}
			else {
				navigateIdea.Show();
				if (navigateIdea.CheckStick(GetStick(), config.dropDownTime))
					Transport();
			}
		}
		else
			ideaManager.HideAll();

	}

	private bool IsPlayerInProximity()
	{
		var inRange = Ranges.InRange(player.GetComponent<Transform>(), transform, config.activationRange);
		return inRange;
	}

	public void Close()
	{
		open = false;
		animator.CrossFade("closed", 0f);
	}

	public void Open()
	{
		if (open)
			return;

		open = true;
		animator.CrossFade("open", 0f);
		ideaManager.HideAll();

		GetDestination().Open();
	}

	protected Navigatable GetDestination()
	{
		return destination.GetComponent<Navigatable>();
	}

	public virtual void Transport() { }
	protected virtual InputControl GetStick() {return null;}
}
