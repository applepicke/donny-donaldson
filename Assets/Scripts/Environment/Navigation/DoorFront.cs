using UnityEngine;
using System.Collections;
using InControl;

public class DoorFront : BottomNavigatable
{

	// Use this for initialization
	protected new void Start()
	{
		base.Start();
		navigateIdea = ideaManager.leftIdea;
		Close();
	}

	protected new InputControl GetStick()
	{
		return InputManager.ActiveDevice.LeftStickUp;
	}
}
