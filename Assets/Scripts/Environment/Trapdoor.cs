using UnityEngine;
using System.Collections;
using InControl;

public class Trapdoor : MonoBehaviour {

	
	private bool open = false;

	//Objects
	private ConfigManager config;
	private IdeaManager ideaManager;
	private Animator animator;
	private GameObject player;
	

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();

		config = GameObject.Find("configManager").GetComponent<ConfigManager>();
		ideaManager = GameObject.Find("ideaManager").GetComponent<IdeaManager>();
		player = GameObject.Find("donny");
	}
	
	// Update is called once per frame
	void Update () {

		if (IsPlayerInProximity())
		{
			if (!open)
			{
				ideaManager.activateIdea.Show();
				if (ideaManager.activateIdea.CheckButton(InputManager.ActiveDevice.Action2, config.activationTime))
					Open();
			}
			else {
				ideaManager.downIdea.Show();
				if (ideaManager.downIdea.CheckStick(InputManager.ActiveDevice.LeftStickDown, config.dropDownTime))
					Drop();
			}
				
		}
		else
			ideaManager.HideAll();
		
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

	public void Drop()
	{
		var pt = player.GetComponent<Transform>();
		pt.position = new Vector2(pt.position.x, pt.position.y - 1);
		ideaManager.HideAll();
	}

	public void Open()
	{
		open = true;
		animator.CrossFade("trapdoor_open", 0f);
		ideaManager.HideAll();
	}
}
