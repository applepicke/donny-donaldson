using UnityEngine;
using System.Collections;
using InControl;

public class PulldownStairs : BottomNavigatable
{

	// Use this for initialization
	protected new void Start()
	{
		base.Start();
		navigateIdea = ideaManager.upIdea;
		Close();
	}

	protected new InputControl GetStick()
	{
		return InputManager.ActiveDevice.LeftStickUp;
	}
}
